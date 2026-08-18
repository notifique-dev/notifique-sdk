/**
 * Generates OpenAPI model classes for all SDK languages (Docker required).
 */
import fs from 'node:fs';
import path from 'node:path';

function rmDir(p) {
  if (fs.existsSync(p)) fs.rmSync(p, { recursive: true, force: true });
}

function copyDir(src, dest) {
  fs.mkdirSync(dest, { recursive: true });
  for (const entry of fs.readdirSync(src, { withFileTypes: true })) {
    const s = path.join(src, entry.name);
    const d = path.join(dest, entry.name);
    if (entry.isDirectory()) copyDir(s, d);
    else fs.copyFileSync(s, d);
  }
}

function runGenerator(root, execSync, { generator, outRel, additionalProperties, globalProperty }) {
  const out = path.join(root, outRel);
  rmDir(out);
  fs.mkdirSync(out, { recursive: true });
  const props = additionalProperties.map((p) => `--additional-properties=${p}`).join(' ');
  const gp = globalProperty ?? 'models,modelTests=false,modelDocs=false,apiTests=false,apiDocs=false,apis=false';
  const cmd = `docker run --rm -v "${root}:/local" openapitools/openapi-generator-cli generate -i /local/openapi/bundled.openapi.json -g ${generator} -o /local/${outRel} --global-property ${gp} ${props}`;
  execSync(cmd, { stdio: 'inherit' });
  return out;
}

function writeJavaSupportingFiles(root, javaFullSrc) {
  const sdkBase = path.join(root, 'packages/sdk-java/src/main/java/dev/notifique/sdk');
  const srcSdk = path.join(javaFullSrc, 'src/main/java/dev/notifique/sdk');
  const allow = new Set([
    'ApiClient.java',
    'ApiException.java',
    'ApiResponse.java',
    'Configuration.java',
    'Pair.java',
    'JSON.java',
    'RFC3339DateFormat.java',
    'RFC3339InstantDeserializer.java',
    'RFC3339JavaTimeModule.java',
    'ServerConfiguration.java',
    'ServerVariable.java',
  ]);
  for (const file of fs.readdirSync(srcSdk)) {
    if (!file.endsWith('.java')) continue;
    if (!allow.has(file)) continue;
    fs.mkdirSync(sdkBase, { recursive: true });
    fs.copyFileSync(path.join(srcSdk, file), path.join(sdkBase, file));
  }
  const abstractSchema = path.join(srcSdk, 'openapi/models/AbstractOpenApiSchema.java');
  if (!fs.existsSync(abstractSchema)) {
    throw new Error(`Missing Java supporting file: ${abstractSchema}`);
  }
  fs.mkdirSync(path.join(sdkBase, 'openapi/models'), { recursive: true });
  fs.copyFileSync(abstractSchema, path.join(sdkBase, 'openapi/models/AbstractOpenApiSchema.java'));
  const staleStub = path.join(sdkBase, 'openapi/ApiClient.java');
  if (fs.existsSync(staleStub)) fs.unlinkSync(staleStub);
  fixJavaModelImports(path.join(sdkBase, 'openapi/models'));
}

function fixJavaModelImports(modelsDir) {
  if (!fs.existsSync(modelsDir)) return;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.java')) continue;
    const filePath = path.join(modelsDir, file);
    let content = fs.readFileSync(filePath, 'utf8');
    let fixed = content
      .replace(/import com\.notifique\.ApiClient;/g, 'import dev.notifique.sdk.ApiClient;')
      .replace(/import com\.notifique\.JSON;/g, 'import dev.notifique.sdk.JSON;');
    if (fixed !== content) fs.writeFileSync(filePath, fixed);
  }
}

function copyCsharpClientHelpers(srcDir, destDir) {
  const allow = new Set([
    'Option.cs',
    'ClientUtils.cs',
    'JsonSerializerOptionsProvider.cs',
    'DateTimeJsonConverter.cs',
    'DateTimeNullableJsonConverter.cs',
    'DateOnlyJsonConverter.cs',
    'DateOnlyNullableJsonConverter.cs',
    'ApiException.cs',
    'ApiResponse`1.cs',
    'CookieContainer.cs',
    'FileParameter.cs',
    'ExceptionEventArgs.cs',
    'ApiResponseEventArgs.cs',
    'TokenBase.cs',
    'TokenProvider`1.cs',
    'TokenContainer`1.cs',
    'RateLimitProvider`1.cs',
  ]);
  rmDir(destDir);
  fs.mkdirSync(destDir, { recursive: true });
  for (const file of fs.readdirSync(srcDir)) {
    if (!allow.has(file)) continue;
    fs.copyFileSync(path.join(srcDir, file), path.join(destDir, file));
  }
}

function fixCsharpClientUtils(clientDir) {
  const file = path.join(clientDir, 'ClientUtils.cs');
  if (!fs.existsSync(file)) return;
  let content = fs.readFileSync(file, 'utf8');
  content = content.replace(/200Response/g, 'Response');
  fs.writeFileSync(file, content);
}

function fixCsharpModels(modelsDir) {
  if (!fs.existsSync(modelsDir)) return;
  for (const file of fs.readdirSync(modelsDir)) {
    if (!file.endsWith('.cs')) continue;
    const full = path.join(modelsDir, file);
    let content = fs.readFileSync(full, 'utf8');
    content = content.replace(/(\w+) = false\b/g, '$1 = 0');
    content = content.replace(/(\w+) = true\b/g, '$1 = 1');
    content = content.replace(
      /public static\s+(\w+Enum)ToJsonValue\(/g,
      'public static string $1ToJsonValue(',
    );
    content = content.replace(
      /case "(\w+)":\s*\n\s*(\w+) = new Option<([^>]+)>\(utf8JsonReader\.TokenType == JsonTokenType\.Null \? \(bool\?\)null : utf8JsonReader\.GetBoolean\(\)\);\s*\n\s*string\? (\w+)RawValue = utf8JsonReader\.GetString\(\);\s*\n\s*if \(\4RawValue != null\)/g,
      'case "$1":\n                            string? $4RawValue;\n                            if (utf8JsonReader.TokenType == JsonTokenType.True || utf8JsonReader.TokenType == JsonTokenType.False)\n                                $4RawValue = utf8JsonReader.GetBoolean().ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant();\n                            else if (utf8JsonReader.TokenType == JsonTokenType.String)\n                                $4RawValue = utf8JsonReader.GetString();\n                            else if (utf8JsonReader.TokenType == JsonTokenType.Null)\n                                $4RawValue = null;\n                            else\n                                throw new JsonException();\n                            if ($4RawValue != null)',
    );
    content = content.replace(
      /if \(successRawValue != null\s*\n\s*if \(successRawValue != null\)/g,
      'if (successRawValue != null)',
    );
    content = content.replace(
      /if \(([^)]+)\)\s*\n\s*writer\.WriteBoolean\("(\w+)", [^)]+\);\s*\n\s*var (\w+)RawValue = ([^;]+);\s*\n\s*writer\.WriteString\("\2", \3RawValue\);/g,
      'if ($1)\n            {\n                var $3RawValue = $4;\n                writer.WriteString("$2", $3RawValue);\n            }',
    );
    content = content.replace(
      /if \(([^)]+)\)\s*\n\s*var (\w+)RawValue = ([^;]+);\s*\n\s*writer\.WriteString\("(\w+)", \2RawValue\);/g,
      'if ($1)\n            {\n                var $2RawValue = $3;\n                writer.WriteString("$4", $2RawValue);\n            }',
    );
    content = content.replace(
      /writer\.WriteBoolean\("(\w+)", [^)]+\.(\w+)\);\s*\n\s*var (\w+)RawValue = ([^;]+);\s*\n\s*writer\.WriteString\("\1", \3RawValue\);/g,
      'var $3RawValue = $4;\n            writer.WriteString("$1", $3RawValue);',
    );
    fs.writeFileSync(full, content);
  }
}

function rewriteElixirModules(dir) {
  for (const file of fs.readdirSync(dir)) {
    const full = path.join(dir, file);
    if (file.endsWith('.ex')) {
      let content = fs.readFileSync(full, 'utf8');
      content = content.replace(/NotifiqueAPI\.Model\./g, 'Notifique.OpenApi.Model.');
      content = content.replace(/defmodule NotifiqueAPI\.Model\./g, 'defmodule Notifique.OpenApi.Model.');
      content = content.replace(/alias NotifiqueAPI\.Deserializer/g, 'alias Notifique.OpenApi.Deserializer');
      content = content.replace(/@derive JSON\.Encoder/g, '@derive Jason.Encoder');
      fs.writeFileSync(full, content);
    }
  }
}

export function generateOpenApiModels({ root, execSync }) {
  const tmp = 'tmp/oagen';
  const bundled = path.join(root, 'openapi/bundled.openapi.json');
  if (!fs.existsSync(bundled)) {
    throw new Error('Missing openapi/bundled.openapi.json — run generate-from-openapi first');
  }

  // Go models + utils
  const goOut = runGenerator(root, execSync, {
    generator: 'go',
    outRel: `${tmp}/go`,
    additionalProperties: ['packageName=openapimodels', 'enumClassPrefix=true'],
    globalProperty: 'models,modelTests=false,modelDocs=false,apiTests=false,apiDocs=false',
  });
  const goDest = path.join(root, 'packages/sdk-go/openapimodels');
  rmDir(goDest);
  fs.mkdirSync(goDest, { recursive: true });
  for (const f of fs.readdirSync(goOut)) {
    if (f.endsWith('.go')) fs.copyFileSync(path.join(goOut, f), path.join(goDest, f));
  }
  const utilsFromClient = path.join(root, 'tmp/goclient/utils.go');
  if (!fs.existsSync(path.join(goDest, 'utils.go')) && fs.existsSync(utilsFromClient)) {
    fs.copyFileSync(utilsFromClient, path.join(goDest, 'utils.go'));
  }

  // Python pydantic v2
  const pyOut = runGenerator(root, execSync, {
    generator: 'python',
    outRel: `${tmp}/python`,
    additionalProperties: ['packageName=notifique.generated.models', 'pydanticVersion=2'],
  });
  const pyDest = path.join(root, 'packages/sdk-python/notifique/generated/models');
  rmDir(pyDest);
  copyDir(path.join(pyOut, 'notifique/generated/models'), pyDest);

  // Java jackson models (native) + supporting JSON/ApiClient/AbstractOpenApiSchema
  const javaModelProps = [
    'modelPackage=dev.notifique.sdk.openapi.models',
    'apiPackage=dev.notifique.sdk',
    'dateLibrary=java8',
    'hideGenerationTimestamp=true',
    'library=native',
    'serializationLibrary=jackson',
    'openApiNullable=false',
  ];
  const javaOut = runGenerator(root, execSync, {
    generator: 'java',
    outRel: `${tmp}/java`,
    additionalProperties: javaModelProps,
  });
  const javaFullOut = runGenerator(root, execSync, {
    generator: 'java',
    outRel: `${tmp}/java-full`,
    additionalProperties: javaModelProps,
    globalProperty: 'apiTests=false,modelTests=false,apiDocs=false',
  });
  const javaOpenapi = path.join(root, 'packages/sdk-java/src/main/java/dev/notifique/sdk/openapi');
  rmDir(javaOpenapi);
  copyDir(path.join(javaOut, 'src/main/java/dev/notifique/sdk/openapi/models'), path.join(javaOpenapi, 'models'));
  writeJavaSupportingFiles(root, javaFullOut);

  // C# models + Client helpers (Option, converters)
  const csOut = runGenerator(root, execSync, {
    generator: 'csharp',
    outRel: `${tmp}/csharp`,
    additionalProperties: [
      'packageName=Notifique.OpenApi.Models',
      'optionalProjectFile=false',
      'hideGenerationTimestamp=true',
      'targetFramework=net8.0',
      'nullableReferenceTypes=true',
    ],
    globalProperty: 'models,modelTests=false,modelDocs=false,apiTests=false,apiDocs=false',
  });
  const csBase = path.join(root, 'packages/sdk-dotnet/src/Notifique/OpenApi');
  rmDir(csBase);
  copyDir(path.join(csOut, 'src/Notifique.OpenApi.Models/Model'), path.join(csBase, 'Models'));
  fixCsharpModels(path.join(csBase, 'Models'));
  const clientFallback = path.join(root, 'packages/sdk-dotnet/openapi-client-stub/Client');
  const clientSrc = path.join(csOut, 'src/Notifique.OpenApi.Models/Client');
  copyCsharpClientHelpers(
    fs.existsSync(clientSrc) ? clientSrc : clientFallback,
    path.join(csBase, 'Client'),
  );
  fixCsharpClientUtils(path.join(csBase, 'Client'));

  // PHP models
  const phpOut = runGenerator(root, execSync, {
    generator: 'php',
    outRel: `${tmp}/php`,
    additionalProperties: [
      'invokerPackage=Notifique\\OpenApi',
      'modelPackage=Notifique\\OpenApi\\Model',
      'hideGenerationTimestamp=true',
    ],
  });
  const phpDest = path.join(root, 'packages/sdk-php/src/OpenApi/Model');
  rmDir(phpDest);
  copyDir(path.join(phpOut, 'lib/Model'), phpDest);

  // Elixir models
  const exOut = runGenerator(root, execSync, {
    generator: 'elixir',
    outRel: `${tmp}/elixir`,
    additionalProperties: ['packageName=notifique_openapi'],
  });
  const exDest = path.join(root, 'packages/sdk-elixir/lib/notifique/openapi/model');
  rmDir(exDest);
  fs.mkdirSync(exDest, { recursive: true });
  const exModelSrc = path.join(exOut, 'lib/notifique_openapi/model');
  const exModelAlt = path.join(exOut, 'lib/notifique_api/model');
  if (fs.existsSync(exModelSrc)) copyDir(exModelSrc, exDest);
  else if (fs.existsSync(exModelAlt)) copyDir(exModelAlt, exDest);
  else throw new Error('Elixir model output not found');
  rewriteElixirModules(exDest);

  console.log('Generated OpenAPI model classes for Go, Python, Java, .NET, PHP, Elixir.');
}

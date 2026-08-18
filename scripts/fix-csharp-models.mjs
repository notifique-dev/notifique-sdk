import fs from 'node:fs';
import path from 'node:path';

const modelsDir = path.join(import.meta.dirname, '../packages/sdk-dotnet/src/Notifique/OpenApi/Models');

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
  fs.writeFileSync(full, content);
}

console.log('Fixed C# models in', modelsDir);

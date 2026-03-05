# Notifique .NET SDK

SDK oficial Notifique para .NET — WhatsApp, SMS, Email, Push e mensagens por template.

## Requisitos

- .NET 8.0 ou superior
- Sem dependências externas (apenas `System.Text.Json`)

## Instalação

### NuGet
```
Install-Package Notifique
```

### .NET CLI
```bash
dotnet add package Notifique
```

## Uso rápido

Recomendado: use `NotifiqueClient` com a base URL atual (`https://api.notifique.dev/v1`).

```csharp
using Notifique;

var client = new NotifiqueClient("sua-api-key");

// Enviar mensagem de texto WhatsApp
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Olá!");

Console.WriteLine($"Status: {response.Data.Status}");
Console.WriteLine($"Message IDs: {string.Join(", ", response.Data.MessageIds)}");
```

Base URL padrão: `https://api.notifique.dev/v1`.

## WhatsApp

### Send Text Message

```csharp
// Single recipient
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello!");

// Multiple recipients
var response = await client.WhatsApp.SendTextAsync("instance-id",
    new List<string> { "5511111111111", "5522222222222" }, "Hello everyone!");
```

### Send Media Message

```csharp
using Notifique.Models.WhatsApp;

var parameters = new WhatsAppSendParams
{
    To = new List<string> { "5511999999999" },
    Type = "image",
    Payload = new MediaPayload(
        MediaUrl: "https://example.com/image.png",
        FileName: "image.png",
        Mimetype: "image/png"
    )
};

var response = await client.WhatsApp.SendAsync("instance-id", parameters);
```

### Send Location

```csharp
var parameters = new WhatsAppSendParams
{
    To = new List<string> { "5511999999999" },
    Type = "location",
    Payload = new LocationPayload(
        Latitude: -23.5505,
        Longitude: -46.6333,
        Name: "Sao Paulo",
        Address: "Sao Paulo, Brazil"
    )
};

var response = await client.WhatsApp.SendAsync("instance-id", parameters);
```

### Send Contact

```csharp
var parameters = new WhatsAppSendParams
{
    To = new List<string> { "5511999999999" },
    Type = "contact",
    Payload = new ContactPayload(new ContactInfo(
        FullName: "John Doe",
        PhoneNumber: "+55 11 99999-9999"
    ))
};

var response = await client.WhatsApp.SendAsync("instance-id", parameters);
```

### Message Operations

```csharp
// List messages (GET /v1/whatsapp/messages)
var list = await client.WhatsApp.ListMessagesAsync();
var listFiltered = await client.WhatsApp.ListMessagesAsync(new Dictionary<string, string> { { "page", "1" }, { "limit", "20" } });

// Get message status (retorna envelope com .Data)
var response = await client.WhatsApp.GetMessageAsync("message-id");
var status = response.Data;

// QR da instância
var qr = await client.WhatsApp.GetInstanceQrAsync("instance-id");

// Edit a message
var edited = await client.WhatsApp.EditMessageAsync("message-id", "Updated text");

// Cancel a scheduled message
var cancelled = await client.WhatsApp.CancelMessageAsync("message-id");

// Delete a message
var deleted = await client.WhatsApp.DeleteMessageAsync("message-id");
```

### Instance Management

```csharp
// List all instances
var instances = await client.WhatsApp.ListInstancesAsync();

// List with pagination
var filtered = await client.WhatsApp.ListInstancesAsync(new Dictionary<string, string>
{
    { "page", "1" },
    { "limit", "10" }
});

// Get a specific instance
var instance = await client.WhatsApp.GetInstanceAsync("instance-id");

// Create a new instance
var created = await client.WhatsApp.CreateInstanceAsync("My Instance");

// Disconnect an instance
var disconnected = await client.WhatsApp.DisconnectInstanceAsync("instance-id");

// Delete an instance
var deleted = await client.WhatsApp.DeleteInstanceAsync("instance-id");
```

## SMS

### Send SMS

```csharp
using Notifique.Models.Sms;

var parameters = new SmsSendParams
{
    To = new List<string> { "5511999999999" },
    Message = "Hello via SMS!"
};

var response = await client.Sms.SendAsync(parameters);
```

### Get SMS Status

```csharp
var status = await client.Sms.GetAsync("sms-id");
Console.WriteLine($"Status: {status.Data.Status}");
```

### Cancel SMS

```csharp
var cancelled = await client.Sms.CancelAsync("sms-id");
```

## Email

### Send Email

```csharp
using Notifique.Models.Email;

var parameters = new EmailSendParams
{
    From = "noreply@yourdomain.com",
    FromName = "Your App",
    To = new List<string> { "user@example.com" },
    Subject = "Welcome!",
    Html = "<h1>Hello!</h1><p>Welcome to our platform.</p>"
};

var response = await client.Email.SendAsync(parameters);
```

### Get Email Status

```csharp
var status = await client.Email.GetAsync("email-id");
```

### Cancel Email

```csharp
var cancelled = await client.Email.CancelAsync("email-id");
```

### Email Domains

```csharp
using Notifique.Models.Email;

var domains = await client.EmailDomains.ListAsync();
var created = await client.EmailDomains.CreateAsync(new CreateEmailDomainRequest { Domain = "meudominio.com" });
var one = await client.EmailDomains.GetAsync("domain-id");
var verified = await client.EmailDomains.VerifyAsync("domain-id");
// verified.Verified indica se o domínio passou na verificação DNS
```

## Push

- **Apps** — `ListAppsAsync()`, `GetAppAsync(id)`, `CreateAppAsync(PushAppCreateRequest)`, `UpdateAppAsync(id, PushAppUpdateRequest)`, `DeleteAppAsync(id)`
- **Devices** — `ListDevicesAsync()`, `GetDeviceAsync(id)`, `RegisterDeviceAsync(PushDeviceRegisterRequest)`, `DeleteDeviceAsync(id)`
- **Messages** — `SendMessageAsync(SendPushRequest)` (agendamento: `request.Schedule.SendAt` usa **sendAt** no JSON), `ListMessagesAsync()`, `GetMessageAsync(id)`, `CancelMessageAsync(id)` retorna `CancelPushResponse`

## Messages (Templates)

### Send Template Message

```csharp
using Notifique.Models.Messages;

var parameters = new MessagesSendParams
{
    To = new List<string> { "5511999999999" },
    Template = "welcome-template",
    Variables = new Dictionary<string, object> { { "name", "User" } },
    Channels = new List<string> { "whatsapp", "sms" },
    InstanceId = "instance-id"
};

var response = await client.Messages.SendAsync(parameters);
```

## Scheduling

All send operations support scheduling via the `Schedule` property:

```csharp
using Notifique.Models.Shared;

var parameters = new SmsSendParams
{
    To = new List<string> { "5511999999999" },
    Message = "Scheduled message",
    Schedule = new Schedule { SendAt = "2025-12-31T23:59:00Z" }
};
```

## Error Handling

All API errors throw a `NotifiqueApiException` with the HTTP status code and response body:

```csharp
try
{
    await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello");
}
catch (NotifiqueApiException ex)
{
    Console.WriteLine($"Status: {ex.StatusCode}");
    Console.WriteLine($"Body: {ex.ResponseBody}");
}
```

## Configuration

### Custom Base URL

```csharp
var client = new NotifiqueClient("your-api-key", "https://custom-api.example.com/v1");
```

### Dependency Injection (IHttpClientFactory)

```csharp
services.AddHttpClient("Notifique");
var httpClient = httpClientFactory.CreateClient("Notifique");
var client = new NotifiqueClient("your-api-key", "https://api.notifique.dev/v1", httpClient);
```

### CancellationToken Support

All async methods accept an optional `CancellationToken`:

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
var response = await client.WhatsApp.SendTextAsync("instance-id", "5511999999999", "Hello", cts.Token);
```

## License

MIT

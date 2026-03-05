using Notifique.Models.Messages;

namespace Notifique;

public sealed class MessagesApi
{
    private readonly NotifiqueClient _client;

    internal MessagesApi(NotifiqueClient client) => _client = client;

    public Task<MessagesSendResponse> SendAsync(MessagesSendParams parameters, CancellationToken cancellationToken = default)
    {
        return _client.RequestAsync<MessagesSendResponse>(HttpMethod.Post, "/templates/send", parameters, cancellationToken);
    }
}

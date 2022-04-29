using System.Threading.Tasks;

namespace XpressTest.Examples.Src;

public class MessagePublisherAsync
{
    private readonly IMessageClientAsyncFactory _messageClientAsyncFactory;

    public MessagePublisherAsync(
        IMessageClientAsyncFactory messageClientAsyncFactory
        )
    {
        _messageClientAsyncFactory = messageClientAsyncFactory;
    }

    public async Task PublishAsync(IMessage message)
    {
        var messageClient = _messageClientAsyncFactory.Create();

        await messageClient.PublishAsync(message);
    }
}
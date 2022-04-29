using System.Threading.Tasks;

namespace XpressTest.Examples.Src;

public class ResultMessagePublisherAsync
{
    private readonly IMessageClientAsyncFactory _messageClientAsyncFactory;

    public ResultMessagePublisherAsync(
        IMessageClientAsyncFactory messageClientAsyncFactory
    )
    {
        _messageClientAsyncFactory = messageClientAsyncFactory;
    }

    public async Task<bool> PublishAsync(IMessage message)
    {
        var messageClient = _messageClientAsyncFactory.Create();

        await messageClient.PublishAsync(message);

        return true;
    }
}
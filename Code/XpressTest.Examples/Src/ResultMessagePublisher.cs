namespace XpressTest.Examples.Src;

public class ResultMessagePublisher
{
    private readonly IMessageClientFactory _messageClientFactory;

    public ResultMessagePublisher(
        IMessageClientFactory messageClientFactory
        )
    {
        _messageClientFactory = messageClientFactory;
    }

    public bool Publish(IMessage message)
    {
        var messageClient = _messageClientFactory.Create();

        messageClient.Publish(message);

        return true;
    }
}
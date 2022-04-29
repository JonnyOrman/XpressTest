namespace XpressTest.Examples.Src;

public class MessagePublisher
{
    private readonly IMessageClientFactory _messageClientFactory;

    public MessagePublisher(
        IMessageClientFactory messageClientFactory
        )
    {
        _messageClientFactory = messageClientFactory;
    }

    public void Publish(IMessage message)
    {
        var messageClient = _messageClientFactory.Create();

        messageClient.Publish(message);
    }
}
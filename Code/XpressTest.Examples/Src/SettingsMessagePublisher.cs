namespace XpressTest.Examples.Src;

public class SettingsMessagePublisher
{
    private readonly IMessageClientFactory _messageClientFactory;
    private readonly MessageSettings _messageSettings;

    public SettingsMessagePublisher(
        IMessageClientFactory messageClientFactory,
        MessageSettings messageSettings
        )
    {
        _messageClientFactory = messageClientFactory;
        _messageSettings = messageSettings;
    }

    public void Publish(IMessage message)
    {
        var messageClient = _messageClientFactory.Create(
            _messageSettings.Topic
            );

        messageClient.Publish(message);
    }
}
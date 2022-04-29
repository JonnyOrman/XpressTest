namespace XpressTest.Examples.Src;

public interface IMessageClientFactory
{
    IMessageClient Create();

    IMessageClient Create(string topic);
}
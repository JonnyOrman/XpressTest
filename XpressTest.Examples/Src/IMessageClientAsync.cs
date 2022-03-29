using System.Threading.Tasks;

namespace XpressTest.Examples.Src;

public interface IMessageClientAsync
{
    Task PublishAsync(IMessage message);
}
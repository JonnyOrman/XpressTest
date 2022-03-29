using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ResultMessagePublisherTests
{
    [Fact]
    public void PublishesMessage_Example1() =>
        GivenA<ResultMessagePublisher>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClient>()
            .WithA<IMessageClientFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturns<IMessageClient>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then<IMessageClientFactory>()
                .Should(messageClientFactory => messageClientFactory.Create())
                .Once()
            .Then<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once()
            .ThenTheResultShouldBe(true);
    
    [Fact]
    public void PublishesMessage_Example2()
    {
        var messageMock = new Mock<IMessage>();

        var messageClient = new Mock<IMessageClient>();
        
        GivenA<ResultMessagePublisher>
                .AndGivenA<IMessageClient>()
            .WithA<IMessageClientFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturns(messageClient.Object)
            .WhenIt(action => action.Sut.Publish(messageMock.Object))
            .Then<IMessageClientFactory>()
                .Should(messageClientFactory => messageClientFactory.Create())
                .Once()
            .Then(messageClient)
                .Should(messageClient => messageClient.Publish(messageMock.Object))
                .Once()
            .ThenTheResultShouldBe(true);
    }
}
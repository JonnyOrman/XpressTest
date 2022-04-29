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
                .AndReturnsTheMock<IMessageClient>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClientFactory>()
                .Should(messageClientFactory => messageClientFactory.Create())
                .Once()
            .ThenThe<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
                .Once()
            .ThenTheResultShouldBe(true);

    [Fact]
    public void PublishesMessage_Example2()
    {
        var messageMock = new Moq.Mock<IMessage>();

        var messageClient = new Moq.Mock<IMessageClient>();

        GivenA<ResultMessagePublisher>
                .AndGivenA<IMessageClient>()
            .WithA<IMessageClientFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturns(messageClient.Object)
            .WhenIt(arrangement => arrangement.Sut.Publish(messageMock.Object))
            .ThenThe<IMessageClientFactory>()
                .Should(messageClientFactory => messageClientFactory.Create())
                .Once()
            .Then(messageClient)
                .Should(messageClient => messageClient.Publish(messageMock.Object))
                .Once()
            .ThenTheResultShouldBe(true);
    }
}
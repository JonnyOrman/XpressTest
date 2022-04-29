using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class MessagePublisherTests
{
    [Fact]
    public void PublishesMessage_Example1() =>
        GivenA<MessagePublisher>
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
                .Once();

    [Fact]
    public void PublishesMessage_Example2() =>
        GivenA<MessagePublisher>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClient>()
            .WithA<IMessageClientFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturnsTheMock<IMessageClient>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetTheMoq<IMessageClientFactory>()
                    .Verify(messageClientFactory => messageClientFactory.Create(), Times.Once);

                assertion
                    .GetTheMoq<IMessageClient>()
                    .Verify(messageClientFactory => messageClientFactory.Publish(assertion.GetTheMockObject<IMessage>()), Times.Once);
            });

    [Fact]
    public void PublishesMessage_Example3() =>
        GivenA<MessagePublisher>
            .AndGivenA<IMessage>("Message")
            .AndGivenA<IMessageClient>("MessageClient")
            .WithA<IMessageClientFactory>()
            .ThatDoes(messageClientFactory => messageClientFactory.Create())
            .AndReturnsTheMock<IMessageClient>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClientFactory>()
            .Should(messageClientFactory => messageClientFactory.Create())
            .Once()
            .ThenThe<IMessageClient>()
            .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
            .Once();
}
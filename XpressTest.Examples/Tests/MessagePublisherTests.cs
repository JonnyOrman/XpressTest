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
                .AndReturns<IMessageClient>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then<IMessageClientFactory>()
                .Should(messageClientFactory => messageClientFactory.Create())
                .Once()
            .Then<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once();
    
    [Fact]
    public void PublishesMessage_Example2() =>
        GivenA<MessagePublisher>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClient>()
            .WithA<IMessageClientFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturns<IMessageClient>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetMock<IMessageClientFactory>()
                    .Verify(messageClientFactory => messageClientFactory.Create(), Times.Once);
                
                assertion
                    .GetMock<IMessageClient>()
                    .Verify(messageClientFactory => messageClientFactory.Publish(assertion.GetMockObject<IMessage>()), Times.Once);
            });
}
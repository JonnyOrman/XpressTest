using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class MessagePublisherAsyncTests
{
    [Fact]
    public void PublishesMessageAsync_Example1() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientFactory => messageClientFactory.Create())
                .AndReturns<IMessageClientAsync>()
            .WhenIt(action => action.Sut.PublishAsync(action.GetMockObject<IMessage>()))
            .Then<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .Then<IMessageClientAsync>()
                .Should(arrangement => messageClient => messageClient.PublishAsync(arrangement.GetMockObject<IMessage>()))
                .Once();
    
    [Fact]
    public void PublishesMessageAsync_Example2() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .AndReturns<IMessageClientAsync>()
            .WhenIt(action => action.Sut.PublishAsync(action.GetMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetMock<IMessageClientAsyncFactory>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.Create(), Times.Once);
                
                assertion
                    .GetMock<IMessageClientAsync>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.PublishAsync(assertion.GetMockObject<IMessage>()), Times.Once);
            });
    
    [Fact]
    public void PublishesMessageAsync_Example3() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
                .AndGivenA<IMessageClientAsyncFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create())
                    .AndReturns<IMessageClientAsync>()
            .WithTheMock<IMessageClientAsyncFactory>()
            .WhenIt(action => action.Sut.PublishAsync(action.GetMockObject<IMessage>()))
            .Then<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .Then<IMessageClientAsync>()
                .Should(arrangement => messageClient => messageClient.PublishAsync(arrangement.GetMockObject<IMessage>()))
                .Once();
    
    [Fact]
    public void PublishesMessageAsync_Example4() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
                .AndGivenA<IMessageClientAsyncFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create())
                    .AndReturns<IMessageClientAsync>()
            .WithTheMock<IMessageClientAsyncFactory>()
            .WhenIt(action => action.Sut.PublishAsync(action.GetMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetMock<IMessageClientAsyncFactory>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.Create(), Times.Once);
                
                assertion
                    .GetMock<IMessageClientAsync>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.PublishAsync(assertion.GetMockObject<IMessage>()), Times.Once);
            });
}
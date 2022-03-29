using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ResultMessagePublisherAsyncTests
{
    [Fact]
    public void PublishesMessage_Example1() =>
        GivenA<ResultMessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .AndReturns<IMessageClientAsync>()
            .WhenItAsync(action => action.Sut.PublishAsync(action.GetMockObject<IMessage>()))
            .Then<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenAsync<IMessageClientAsync>()
                .Should(arrangement => messageClientAsync => messageClientAsync.PublishAsync(arrangement.GetMockObject<IMessage>()))
                .Once()
            .ThenTheResultShouldBe(true);
    
    [Fact]
    public void PublishesMessage_Example2()
    {
        var messageMock = new Mock<IMessage>();

        var messageClientAsync = new Mock<IMessageClientAsync>();
        
        GivenA<ResultMessagePublisherAsync>
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .AndReturns(messageClientAsync.Object)
            .WhenItAsync(action => action.Sut.PublishAsync(messageMock.Object))
            .Then<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenAsync(messageClientAsync)
                .Should(messageClientAsync => messageClientAsync.PublishAsync(messageMock.Object))
                .Once()
            .ThenTheResultShouldBe(true);
    }
}
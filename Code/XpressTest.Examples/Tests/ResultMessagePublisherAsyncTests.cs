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
                .AndReturnsTheMock<IMessageClientAsync>()
            .WhenItAsync(arrangement => arrangement.Sut.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenTheAsync<IMessageClientAsync>()
                .Should(arrangement => messageClientAsync => messageClientAsync.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
                .Once()
            .ThenTheResultShouldBe(true);

    [Fact]
    public void PublishesMessage_Example2()
    {
        var messageMock = new Moq.Mock<IMessage>();

        var messageClientAsync = new Moq.Mock<IMessageClientAsync>();

        GivenA<ResultMessagePublisherAsync>
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .AndReturns(messageClientAsync.Object)
            .WhenItAsync(arrangement => arrangement.Sut.PublishAsync(messageMock.Object))
            .ThenThe<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenAsync(messageClientAsync)
                .Should(messageClientAsync => messageClientAsync.PublishAsync(messageMock.Object))
                .Once()
            .ThenTheResultShouldBe(true);
    }
}
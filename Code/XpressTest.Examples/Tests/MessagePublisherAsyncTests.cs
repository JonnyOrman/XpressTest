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
                .AndReturnsTheMock<IMessageClientAsync>()
            .WhenIt(arrangement => arrangement.Sut.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenThe<IMessageClientAsync>()
                .Should(arrangement => messageClient => messageClient.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
                .Once();

    [Fact]
    public void PublishesMessageAsync_Example2() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
            .WithA<IMessageClientAsyncFactory>()
                .ThatDoes(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .AndReturnsTheMock<IMessageClientAsync>()
            .WhenIt(arrangement => arrangement.Sut.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetTheMoq<IMessageClientAsyncFactory>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.Create(), Times.Once);

                assertion
                    .GetTheMoq<IMessageClientAsync>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.PublishAsync(assertion.GetTheMockObject<IMessage>()), Times.Once);
            });

    [Fact]
    public void PublishesMessageAsync_Example3() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
                .AndGivenA<IMessageClientAsyncFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create())
                    .AndReturnsTheMock<IMessageClientAsync>()
            .WithTheMock<IMessageClientAsyncFactory>()
            .WhenIt(arrangement => arrangement.Sut.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClientAsyncFactory>()
                .Should(messageClientAsyncFactory => messageClientAsyncFactory.Create())
                .Once()
            .ThenThe<IMessageClientAsync>()
                .Should(arrangement => messageClient => messageClient.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
                .Once();

    [Fact]
    public void PublishesMessageAsync_Example4() =>
        GivenA<MessagePublisherAsync>
                .AndGivenA<IMessage>()
                .AndGivenA<IMessageClientAsync>()
                .AndGivenA<IMessageClientAsyncFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create())
                    .AndReturnsTheMock<IMessageClientAsync>()
            .WithTheMock<IMessageClientAsyncFactory>()
            .WhenIt(arrangement => arrangement.Sut.PublishAsync(arrangement.GetTheMockObject<IMessage>()))
            .Then(assertion =>
            {
                assertion
                    .GetTheMoq<IMessageClientAsyncFactory>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.Create(), Times.Once);

                assertion
                    .GetTheMoq<IMessageClientAsync>()
                    .Verify(messageClientAsyncFactory => messageClientAsyncFactory.PublishAsync(assertion.GetTheMockObject<IMessage>()), Times.Once);
            });
}
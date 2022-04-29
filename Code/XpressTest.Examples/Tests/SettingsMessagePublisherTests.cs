using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class SettingsMessagePublisherTests
{
    [Fact]
    public void PublishesMessage_Example1() =>
        GivenA<SettingsMessagePublisher>
                .AndGivenA<IMessageClientFactory>()
                .AndGivenA<IMessageClient>()
                .AndGivenA<IMessage>()
                .AndGiven("topic-name")
                .AndGiven(arrangement => new MessageSettings(arrangement.GetThe<string>()))
            .WithTheMock<IMessageClientFactory>()
                .ThatDoes<IMessageClient>(arrangement => messageClientFactory => messageClientFactory.Create(arrangement.GetThe<string>()))
                .AndReturns(arrangement => arrangement.GetTheMockObject<IMessageClient>())
            .WithThe<MessageSettings>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
                .Once();

    [Fact]
    public void PublishesMessage_Example2() =>
        GivenA<SettingsMessagePublisher>
                .AndGiven("topic-name")
                .AndGivenA<IMessageClient>()
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes<IMessageClient>(arrangement => messageClientFactory => messageClientFactory.Create(arrangement.GetThe<string>()))
                    .AndReturns(arrangement => arrangement.GetTheMockObject<IMessageClient>())
                .AndGivenA<IMessage>()
                .AndGiven(arrangement => new MessageSettings(arrangement.GetThe<string>()))
            .WithTheMock<IMessageClientFactory>()
            .WithThe<MessageSettings>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .ThenThe<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
                .Once();

    [Fact]
    public void PublishesMessage_Example3()
    {
        var messageClientMock = new Moq.Mock<IMessageClient>();

        GivenA<SettingsMessagePublisher>
                .AndGiven("topic-name")
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes<IMessageClient>(arrangement =>
                messageClientFactory => messageClientFactory.Create(arrangement.GetThe<string>()))
                    .AndReturns(messageClientMock.Object)
                .AndGivenA<IMessage>()
                .AndGiven(arrangement => new MessageSettings(arrangement.GetThe<string>()))
            .WithTheMock<IMessageClientFactory>()
            .WithThe<MessageSettings>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .Then(messageClientMock)
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
                .Once();
    }

    [Fact]
    public void PublishesMessage_Example4()
    {
        var topic = "topic-name";

        var messageClientMock = new Moq.Mock<IMessageClient>();

        GivenA<SettingsMessagePublisher>
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create(topic))
                    .AndReturns(messageClientMock.Object)
                .AndGivenA<IMessage>()
                .AndGiven(new MessageSettings(topic))
            .WithTheMock<IMessageClientFactory>()
            .WithThe<MessageSettings>()
            .WhenIt(arrangement => arrangement.Sut.Publish(arrangement.GetTheMockObject<IMessage>()))
            .Then(messageClientMock)
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetTheMockObject<IMessage>()))
                .Once();
    }
}
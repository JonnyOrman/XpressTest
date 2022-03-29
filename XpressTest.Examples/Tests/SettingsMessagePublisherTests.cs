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
                .AndReturns(arrangement => arrangement.GetMockObject<IMessageClient>())
            .With<MessageSettings>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once();
    
    [Fact]
    public void PublishesMessage_Example2() =>
        GivenA<SettingsMessagePublisher>
                .AndGiven("topic-name")
                .AndGivenA<IMessageClient>()
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes<IMessageClient>(arrangement => messageClientFactory => messageClientFactory.Create(arrangement.GetThe<string>()))
                    .AndReturns(arrangement => arrangement.GetMockObject<IMessageClient>())
                .AndGivenA<IMessage>()
                .AndGiven(arrangement => new MessageSettings(arrangement.GetThe<string>()))
            .WithTheMock<IMessageClientFactory>()
            .With<MessageSettings>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then<IMessageClient>()
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once();

    [Fact]
    public void PublishesMessage_Example3()
    {
        var messageClientMock = new Mock<IMessageClient>();
        
        GivenA<SettingsMessagePublisher>
                .AndGiven("topic-name")
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes<IMessageClient>(arrangement =>
                messageClientFactory => messageClientFactory.Create(arrangement.GetThe<string>()))
                    .AndReturns(messageClientMock.Object)
                .AndGivenA<IMessage>()
                .AndGiven(arrangement => new MessageSettings(arrangement.GetThe<string>()))
            .WithTheMock<IMessageClientFactory>()
            .With<MessageSettings>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then(messageClientMock)
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once();
    }
    
    [Fact]
    public void PublishesMessage_Example4()
    {
        var topic = "topic-name";
        
        var messageClientMock = new Mock<IMessageClient>();
        
        GivenA<SettingsMessagePublisher>
                .AndGivenA<IMessageClientFactory>()
                    .ThatDoes(messageClientFactory => messageClientFactory.Create(topic))
                    .AndReturns(messageClientMock.Object)
                .AndGivenA<IMessage>()
                .AndGiven(new MessageSettings(topic))
            .WithTheMock<IMessageClientFactory>()
            .With<MessageSettings>()
            .WhenIt(action => action.Sut.Publish(action.GetMockObject<IMessage>()))
            .Then(messageClientMock)
                .Should(arrangement => messageClient => messageClient.Publish(arrangement.GetMockObject<IMessage>()))
                .Once();
    }
}
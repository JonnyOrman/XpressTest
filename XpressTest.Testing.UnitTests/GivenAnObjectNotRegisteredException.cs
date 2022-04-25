using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnObjectNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheMessage()
    {
        var message = "Message";
        
        var sut = new ObjectNotRegisteredException(message);

        sut.Message.Should().Be(message);
    }
}
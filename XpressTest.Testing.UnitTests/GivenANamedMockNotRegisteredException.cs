using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheMessage()
    {
        var sut = new NamedMockNotRegisteredException("Message");

        sut.Message.Should().Be("Message");
    }
}
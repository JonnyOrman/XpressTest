using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockDifferentTypeRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItaHasTheMessage()
    {
        var sut = new NamedMockDifferentTypeRegisteredException("Message");

        sut.Message.Should().Be("Message");
    }
}
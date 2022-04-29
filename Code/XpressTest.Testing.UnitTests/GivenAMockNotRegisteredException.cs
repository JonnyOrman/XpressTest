using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new MockNotRegisteredException<object>();

        sut.Message.Should().Be($"No mock of type Object registered");
        sut.MockType.Should().Be(typeof(object));
    }
}
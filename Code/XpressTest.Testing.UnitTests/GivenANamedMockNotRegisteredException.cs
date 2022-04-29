using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new NamedMockNotRegisteredException<object>("MockName");

        sut.Message.Should().Be("No mock of type Object with name MockName registered");
        sut.MockType.Should().Be(typeof(object));
    }
}
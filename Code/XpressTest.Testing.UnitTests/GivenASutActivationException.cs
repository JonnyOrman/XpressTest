using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutActivationException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new SutActivationException<object>();

        sut.Message.Should().Be("Failed to activate Sut of type Object");
        sut.SutType.Should().Be(typeof(object));
    }
}
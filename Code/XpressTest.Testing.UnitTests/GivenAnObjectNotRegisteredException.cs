using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnObjectNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new ObjectNotRegisteredException<object>();

        sut.Message.Should().Be("No object of type Object registered");
        sut.ObjectType.Should().Be(typeof(object));
    }
}
using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnUnnamedObjectTypeAlreadyRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new UnnamedObjectTypeAlreadyRegisteredException<object>();

        sut.Message.Should().Be("An unnamed object of type Object has already been registered. If more than one object of the same type is registered then they must each be registered with a unique name.");
        sut.ObjectType.Should().Be(typeof(object));
    }
}
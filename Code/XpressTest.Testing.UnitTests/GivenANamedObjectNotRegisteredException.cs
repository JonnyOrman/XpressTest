using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedObjectNotRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new NamedObjectNotRegisteredException<object>("ObjectName");

        sut.Message.Should().Be("No object of type Object with name ObjectName registered");
        sut.ObjectType.Should().Be(typeof(object));
    }
}
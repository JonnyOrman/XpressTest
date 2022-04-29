using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedObject
{
    [Fact]
    public void WhenItIsConstructedThenItHasThePropertyValues()
    {
        var obj = new object();

        var name = "ObjectName";

        var sut = new NamedObject<object>(
            obj,
            name
            );

        sut.Object.Should().Be(obj);
        sut.Name.Should().Be(name);
    }
}
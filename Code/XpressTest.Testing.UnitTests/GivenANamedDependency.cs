using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedDependency
{
    [Fact]
    public void WhenItIsConstructedThenItHasAllPropertyValues()
    {
        var obj = new object();

        var name = "ObjectName";

        var sut = new NamedDependency<object>(
            obj,
            name
            );

        sut.Object.Should().Be(obj);
        sut.Name.Should().Be(name);
    }
}
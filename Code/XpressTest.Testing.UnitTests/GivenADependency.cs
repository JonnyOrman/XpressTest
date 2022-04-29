using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependency
{
    [Fact]
    public void WhenItIsConstructedThenItShouldHaveTheObject()
    {
        var obj = new object();

        var sut = new Dependency<object>(
            obj
            );

        sut.Object.Should().Be(obj);
    }
}
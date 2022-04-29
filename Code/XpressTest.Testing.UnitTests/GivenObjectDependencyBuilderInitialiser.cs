using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenObjectDependencyBuilderInitialiser
{
    [Fact]
    public void WhenItInitialisesAnObjectDependencyBuilderThenItCreatesAnObjectDependencyBuilder()
    {
        var dependency = new object();

        var result = ObjectDependencyBuilderInitialiser<object>.Initialise(dependency);

        result.Should().NotBeNull();
    }
}
using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenNamedDependencyTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithADependencyBuilderThenItReturnsADependencyBuilder()
    {
        var dependency = new object();

        var name = "DependencyName";

        var result = NamedDependencyTestInitialiser<object>.Initialise(
            dependency,
            name
        );

        result.Should().NotBeNull();
    }
}
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenDependencySetterInitialiser
{
    [Fact]
    public void WhenItInitialisesADependencySetterThenItReturnsADependencySetter()
    {
        var arrangement = Substitute.For<IArrangement>();

        var result = DependencySetterInitialiser<object>.Initialise(
            arrangement
            );

        result.Should().NotBeNull();
    }
}
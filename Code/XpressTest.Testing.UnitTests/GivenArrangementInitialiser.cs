using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenArrangementInitialiser
{
    [Fact]
    public void WhenItInitialisesAnArrangementThenItReturnsAnArrangement()
    {
        var result = ArrangementInitialiser.Initialise();

        result.Should().NotBeNull();
        result.Dependencies.Should().NotBeNull();
        result.Objects.Should().NotBeNull();
        result.MockObjects.Should().NotBeNull();
    }
}
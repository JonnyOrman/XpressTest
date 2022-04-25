using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAsserterCreatorInitialiser
{
    [Fact]
    public void WhenAnAsserterCreatorIsInitialisedThenItReturnsAnAsserterCreator()
    {
        var arrangement = Substitute.For<IArrangement>();
        
        var result = AsserterCreatorInitialiser<object>.Initialise(
            arrangement
            );

        result.Should().NotBeNull();
    }
}
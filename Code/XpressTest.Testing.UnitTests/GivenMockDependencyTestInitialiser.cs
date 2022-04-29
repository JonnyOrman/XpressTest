using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenMockDependencyTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithAMockDependencyThenItCreatesAMockDependencySetupBuilder()
    {
        var result = MockDependencyTestInitialiser<object>.Initialise<object>();

        result.Should().BeOfType<MockDependencySetupBuilder<object, object, IMock<object>>>();
    }
}
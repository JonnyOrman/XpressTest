using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenMockObjectTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithAMockObjectThenItCreatesAMockSetupBuilder()
    {
        var result = MockObjectTestInitialiser<object, object>.Initialise();

        result.Should().BeOfType<MockSetupBuilder<object, object, IMock<object>>>();
    }
}
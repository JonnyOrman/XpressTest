using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenNamedMockObjectTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithANamedMockThenItCreatesANamedMockSetupBuilder()
    {
        var result = NamedMockObjectTestInitialiser<object, object>.Initialise("MockName");

        result.Should().NotBeNull();
    }
}
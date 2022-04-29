using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockSetupBuilderCreator
{
    [Fact]
    public void WhenItCreatesAMockSetupBuilderThenItReturnsAMockSetupBuilder()
    {
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var sut = new MockSetupBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            namedMockSetupBuilderCreator
            );

        var result = sut.Create<object>();

        result.Should().NotBeNull();
    }
}
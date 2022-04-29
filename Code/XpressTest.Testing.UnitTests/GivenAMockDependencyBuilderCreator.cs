using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesAMockDependencyBuilderThenItReturnsAMockDependencySetupBuilder()
    {
        var mock = Substitute.For<IMock<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new MockDependencyBuilderCreator<object>(
            arrangement,
            dependencyBuilderChainer
            );

        var result = sut.Create(mock);

        result.Should().BeOfType<MockDependencySetupBuilder<object, object, IMock<object>>>();
    }
}
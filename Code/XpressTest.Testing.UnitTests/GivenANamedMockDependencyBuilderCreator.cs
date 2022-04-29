using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesANamedMockDependencyBuilderThenItCreatesANamedMockDependencySetupBuilder()
    {
        var dependencyName = "DependencyName";

        var arrangement = Substitute.For<IArrangement>();

        var mockDependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new NamedMockDependencyBuilderCreator<object>(
            arrangement,
            mockDependencyBuilderChainer
            );

        var result = sut.Create<object>(dependencyName);

        result.Should().BeOfType<MockDependencySetupBuilder<object, object, INamedMock<object>>>();
    }
}
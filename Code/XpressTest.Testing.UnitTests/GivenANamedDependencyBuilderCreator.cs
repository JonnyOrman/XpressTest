using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesANamedDependencyBuilderThenItReturnsANamedDependencyBuilder()
    {
        var dependency = new object();

        var name = "DependencyName";

        var arrangement = Substitute.For<IArrangement>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new NamedDependencyBuilderCreator<object>(
            arrangement,
            dependencyBuilderChainer
            );

        var result = sut.Create(
            dependency,
            name
        );

        result.Should().BeOfType<DependencyBuilder<object, INamedDependency>>();
    }
}
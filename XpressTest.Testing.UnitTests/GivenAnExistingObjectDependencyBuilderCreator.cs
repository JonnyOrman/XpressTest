using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnExistingObjectDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesADependencyBuilderThenItGetsTheDependencyAndReturnsTheDependencyBuilder()
    {
        var arrangement = Substitute.For<IArrangement>();

        var sut = new ExistingObjectDependencyBuilderCreator<object>(
            null,
            arrangement
        );

        var result = sut.Create<object>();

        arrangement.Received(1).GetThe<object>();
        
        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItCreatesANamedDependencyBuilderThenItGetsTheNamedDependencyAndReturnsTheDependencyBuilder()
    {
        var dependencyName = "DependencyName";
        
        var arrangement = Substitute.For<IArrangement>();

        var sut = new ExistingObjectDependencyBuilderCreator<object>(
            null,
            arrangement
        );

        var result = sut.Create<object>(dependencyName);

        arrangement.Received(1).GetThe<object>(dependencyName);
        
        result.Should().NotBeNull();
    }
}
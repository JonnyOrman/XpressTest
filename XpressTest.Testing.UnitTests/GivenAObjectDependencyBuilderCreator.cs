using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAObjectDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesADependencyBuilderForAnObjectThenItReturnsAnObjectDependencyBuilder()
    {
        var dependency = new object();
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new ObjectDependencyBuilderCreator<object>(
            testBuilderContainer,
            arrangement
            );

        var result = sut.Create(dependency);

        result.Should().BeOfType<DependencyBuilder<object, object>>();
    }
    
    [Fact]
    public void WhenItCreatesADependencyBuilderFromAnArrangementFuncThenItReturnsAnObjectDependencyBuilder()
    {
        Func<IReadArrangement, object> dependency = arrangement => new object();
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new ObjectDependencyBuilderCreator<object>(
            testBuilderContainer,
            arrangement
        );

        var result = sut.Create(dependency);

        result.Should().BeOfType<DependencyBuilder<object, object>>();
    }
}
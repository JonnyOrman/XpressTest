using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnArrangementSutComposer
{
    [Fact]
    public void WhenNoDependenciesAreRegisteredAndTheSutHasADefaultConstructorThenTheSutIsActivated()
    {
        var dependencies = Substitute.For<IDependencyCollection>();
        
        var arrangement = Substitute.For<IArrangement>();
        arrangement.Dependencies.Returns(dependencies);
        
        var sut = new ArrangementSutComposer<object>(
            arrangement
            );

        var result = sut.Compose();

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenDependenciesAreRegisteredAndTheSutDoesNotHaveAMatchingConstructorThenAMissingMethodExceptionIsThrown()
    {
        var dependency = new Dependency<object>(new object());

        var dependencyList = new List<IDependency>
        {
            dependency
        };
        
        var dependencies = Substitute.For<IDependencyCollection>();
        dependencies.Any().Returns(true);
        dependencies.GetAll().Returns(dependencyList);
        
        var arrangement = Substitute.For<IArrangement>();
        arrangement.Dependencies.Returns(dependencies);
        
        var sut = new ArrangementSutComposer<object>(
            arrangement
        );

        Assert.Throws<MissingMethodException>(() => sut.Compose());
    }
    
    [Fact]
    public void WhenDependenciesAreRegisteredAndTheSutHasAMatchingConstructorThenTheSutIsActivated()
    {
        var dependency = new Dependency<object>(new object());

        var dependencyList = new List<IDependency>
        {
            dependency
        };
        
        var dependencies = Substitute.For<IDependencyCollection>();
        dependencies.Any().Returns(true);
        dependencies.GetAll().Returns(dependencyList);
        
        var arrangement = Substitute.For<IArrangement>();
        arrangement.Dependencies.Returns(dependencies);
        
        var sut = new ArrangementSutComposer<TestSut>(
            arrangement
        );

        var result = sut.Compose();

        result.Should().NotBeNull();
    }
}
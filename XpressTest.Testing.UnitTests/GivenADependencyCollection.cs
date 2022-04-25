using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependencyCollection
{
    [Fact]
    public void WhenItAddsADependencyThenTheDependencyIsAddedToTheCollection()
    {
        var dependency = Substitute.For<IDependency>();
        
        var collection = Substitute.For<ICollection<IDependency>>();
        
        var sut = new DependencyCollection(
            collection
            );
        
        sut.Add(dependency);

        collection.Received(1).Add(dependency);
    }
    
    [Fact]
    public void WhenItAddsANullDependencyThenTheNullDependencyIsNotAddedToTheCollection()
    {
        IDependency dependency = null;
        
        var collection = Substitute.For<ICollection<IDependency>>();
        
        var sut = new DependencyCollection(
            collection
        );
        
        sut.Add(dependency);

        collection.DidNotReceive().Add(Arg.Any<IDependency>());
    }
    
    [Fact]
    public void WhenItAddsANamedDependencyThenTheNamedDependencyIsAddedToTheDictionaryAndTheCollection()
    {
        var dependencyName = "DependencyName";
        
        var namedDependency = Substitute.For<INamedDependency>();
        namedDependency.Name.Returns(dependencyName);
        
        var collection = Substitute.For<ICollection<IDependency>>();
        
        var sut = new DependencyCollection(
            collection
        );
        
        sut.Add(namedDependency);

        collection.Received(1).Add(namedDependency);
    }
    
    [Fact]
    public void WhenItChecksIfThereAreAnyDependenciesAndThereIsOneThenItReturnsTrue()
    {
        var dependency = Substitute.For<IDependency>();
        
        var collection = new List<IDependency>();
        collection.Add(dependency);
        
        var sut = new DependencyCollection(
            collection
        );
        
        var result = sut.Any();

        result.Should().BeTrue();
    }
    
    [Fact]
    public void WhenItChecksIfThereAreAnyDependenciesAndThereAreNoneThenItReturnsFalse()
    {
        var collection = new List<IDependency>();
        
        var sut = new DependencyCollection(
            collection
        );
        
        var result = sut.Any();

        result.Should().BeFalse();
    }
    
    [Fact]
    public void WhenItGetsAllDependenciesThenItReturnsTheCollection()
    {
        var collection = Substitute.For<ICollection<IDependency>>();
        
        var sut = new DependencyCollection(
            collection
        );
        
        var result = sut.GetAll();

        Assert.Same(collection, result);
    }
}
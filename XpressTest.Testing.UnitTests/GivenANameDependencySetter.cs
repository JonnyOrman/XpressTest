using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANameDependencySetter
{
    [Fact]
    public void WhenItSetsANamedDependencyThenItAddTheDependencyAndANamedObjectToTheArrangement()
    {
        var dependency = new object();

        var name = "DependencyName";
        
        var namedDependency = Substitute.For<INamedDependency>();
        namedDependency.Object.Returns(dependency);
        namedDependency.Name.Returns(name);
        
        var dependencyCollection = Substitute.For<IDependencyCollection>();
        
        var arrangement = Substitute.For<IArrangement>();
        arrangement.Dependencies.Returns(dependencyCollection);
        
        var sut = new NameDependencySetter<object>(
            arrangement
            );
        
        sut.Set(namedDependency);
        
        dependencyCollection.Received(1).Add(namedDependency);
        arrangement.Received(1).Add(Arg.Is<INamedObject<object>>(namedObject
            => namedObject.Object == dependency
            && namedObject.Name == name));
    }
}
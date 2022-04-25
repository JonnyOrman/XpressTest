using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockDependencySetter
{
    [Fact]
    public void WhenItSetsANamedMockDependencyThenItAddsItAsANamedDependencyAndAsANamedMock()
    {
        var dependency = new object();

        var dependencyName = "DepndencyName";
        
        var namedMockDependency = Substitute.For<INamedMock<object>>();
        namedMockDependency.Object.Returns(dependency);
        namedMockDependency.Name.Returns(dependencyName);
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new NamedMockDependencySetter<object>(arrangement);
        
        sut.Set(namedMockDependency);
        
        arrangement.Received(1).AddDependency(dependency, dependencyName);
        arrangement.Received(1).Add(namedMockDependency);
    }
}
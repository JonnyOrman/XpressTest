using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnExistingObjectDependencySetter
{
    [Fact]
    public void WhenItSetsAnExistingObjectDependencyThenItAddsTheExistingObjectToTheDependencies()
    {
        var obj = new object();
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new ExistingObjectDependencySetter<object>(arrangement);
        
        sut.Set(obj);

        arrangement.Received(1).AddDependency(obj);
    }
}
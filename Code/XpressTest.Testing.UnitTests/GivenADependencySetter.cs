using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependencySetter
{
    [Fact]
    public void WhenItSetsADependencyThenItAddsTheDependencyToTheObjectsAndDependencies()
    {
        var obj = new object();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new DependencySetter<object>(
            arrangement
            );

        sut.Set(obj);

        arrangement.Received(1).Add(obj);
        arrangement.Received(1).AddDependency(obj);
    }
}
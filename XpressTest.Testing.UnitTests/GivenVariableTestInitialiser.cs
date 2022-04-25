using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenVariableTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithAVariableThenItReturnsAVariableBuilder()
    {
        var obj = new object();

        var objectCollection = Substitute.For<IObjectCollection>();

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();

        var dependencyCollection = Substitute.For<IDependencyCollection>();
        
        var arrangement = Substitute.For<IArrangement>();
        arrangement.Objects.Returns(objectCollection);
        arrangement.MockObjects.Returns(mockObjectCollection);
        arrangement.Dependencies.Returns(dependencyCollection);

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();
        
        var result = VariableTestInitialiser<object, object>.Initialise(
            obj,
            arrangement,
            arrangementSetter
            );

        result.Should().BeOfType<VariableBuilder<object, object, IVariableBuilderChainer<object>>>();
    }
}
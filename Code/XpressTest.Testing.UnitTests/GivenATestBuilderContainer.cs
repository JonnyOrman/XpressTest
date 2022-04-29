using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenATestBuilderContainer
{
    [Fact]
    public void WhenItIsConstructedThenItHasThePropertyValues()
    {
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();

        var variableBuilderCreator = Substitute.For<IVariableBuilderCreator<object>>();

        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();

        var sut = new TestBuilderContainer<object>(asserterCreator)
        {
            VariableBuilderCreator = variableBuilderCreator,
            DependencyBuilderCreator = dependencyBuilderCreator
        };

        sut.AsserterCreator.Should().Be(asserterCreator);
        sut.VariableBuilderCreator.Should().Be(variableBuilderCreator);
        sut.DependencyBuilderCreator.Should().Be(dependencyBuilderCreator);
    }
}
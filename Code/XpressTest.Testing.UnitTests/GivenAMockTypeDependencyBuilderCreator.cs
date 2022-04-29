using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockTypeDependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesAMockDependencyBuilderForANewDependencyThenItCreatesAMoqMockDependencyBuilder()
    {
        var arrangement = Substitute.For<IArrangement>();

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var mockDependencyBuilderCreator = Substitute.For<IMockDependencyBuilderCreator<object>>();
        mockDependencyBuilderCreator.Create(Arg.Any<IMock<object>>()).Returns(mockDependencySetupBuilder);

        var sut = new MockTypeDependencyBuilderCreator<object>(
            arrangement,
            mockDependencyBuilderCreator
            );

        var result = sut.Create<object>();

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void WhenItCreatesAMockDependencyBuilderForAnExistingDependencyThenItCreatesAMoqMockDependencyBuilder()
    {
        var mock = Substitute.For<IMock<object>>();

        var arrangement = Substitute.For<IArrangement>();
        arrangement.GetTheMock<object>().Returns(mock);

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var mockDependencyBuilderCreator = Substitute.For<IMockDependencyBuilderCreator<object>>();
        mockDependencyBuilderCreator.Create(mock).Returns(mockDependencySetupBuilder);

        var sut = new MockTypeDependencyBuilderCreator<object>(
            arrangement,
            mockDependencyBuilderCreator
        );

        var result = sut.CreateExisting<object>();

        result.Should().Be(mockDependencySetupBuilder);
    }
}
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAContainer
{
    [Fact]
    public void WhenItIsConstructedThenItHasAllProperties()
    {
        var objectDependencyBuilderCreator = Substitute.For<IObjectDependencyBuilderCreator<object>>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var mockDependencyBuilderCreator = Substitute.For<IMockDependencyBuilderCreator<object>>();

        var namedDependencyBuilderCreator = Substitute.For<INamedDependencyBuilderCreator<object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var sut = new Container<object>(
            objectDependencyBuilderCreator,
            mockSetupBuilderCreator,
            mockDependencyBuilderCreator,
            namedDependencyBuilderCreator,
            namedMockSetupBuilderCreator,
            testBuilderContainer
            );

        sut.ObjectDependencyBuilderCreator.Should().Be(objectDependencyBuilderCreator);
        sut.MockSetupBuilderCreator.Should().Be(mockSetupBuilderCreator);
        sut.MockDependencyBuilderCreator.Should().Be(mockDependencyBuilderCreator);
        sut.NamedDependencyBuilderCreator.Should().Be(namedDependencyBuilderCreator);
        sut.NamedMockSetupBuilderCreator.Should().Be(namedMockSetupBuilderCreator);
        sut.TestBuilderContainer.Should().Be(testBuilderContainer);
    }
}
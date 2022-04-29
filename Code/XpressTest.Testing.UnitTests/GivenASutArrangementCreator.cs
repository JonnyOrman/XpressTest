using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutArrangementCreator
{
    [Fact]
    public void WhenItCreatesASutArrangementThenItReturnsASutArrangementWithTheExpectedProperties()
    {
        var testSut = new object();

        var sutComposer = Substitute.For<ISutComposer<object>>();
        sutComposer.Compose().Returns(testSut);

        var objectCollection = Substitute.For<IObjectCollection>();
        var dependencyCollection = Substitute.For<IDependencyCollection>();
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();

        var arrangement = Substitute.For<IArrangement>();
        arrangement.Objects.Returns(objectCollection);
        arrangement.Dependencies.Returns(dependencyCollection);
        arrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new SutArrangementCreator<object>(
            sutComposer,
            arrangement
        );

        var result = sut.Create();

        result.Sut.Should().Be(testSut);
        result.Objects.Should().Be(objectCollection);
        result.Dependencies.Should().Be(dependencyCollection);
        result.MockObjects.Should().Be(mockObjectCollection);
    }
}
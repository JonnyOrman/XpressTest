using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidAssertion
{
    [Fact]
    public void WhenItGetsTheObjectsThenItReturnsTheObjects()
    {
        var objectCollection = Substitute.For<IObjectCollection>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Objects.Returns(objectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
            );

        var result = sut.Objects;

        result.Should().Be(objectCollection);
    }

    [Fact]
    public void WhenItGetsTheMockObjectsThenItReturnsTheObjects()
    {
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.MockObjects;

        result.Should().Be(mockObjectCollection);
    }

    [Fact]
    public void WhenItGetsTheDependenciesThenItReturnsTheObjects()
    {
        var dependencyCollection = Substitute.For<IDependencyCollection>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Dependencies.Returns(dependencyCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.Dependencies;

        result.Should().Be(dependencyCollection);
    }

    [Fact]
    public void WhenItGetsAnObjectThenItReturnsTheObject()
    {
        var obj = new object();

        var objectCollection = Substitute.For<IObjectCollection>();
        objectCollection.Get<object>().Returns(obj);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Objects.Returns(objectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetThe<object>();

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsANamedObjectThenItReturnsTheNamedObject()
    {
        var obj = new object();

        var objectName = "ObjectName";

        var objectCollection = Substitute.For<IObjectCollection>();
        objectCollection.Get<object>(objectName).Returns(obj);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Objects.Returns(objectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetThe<object>(objectName);

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsAMockThenItReturnsTheMock()
    {
        var mock = Substitute.For<IMock<object>>();

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetTheMock<object>();

        result.Should().Be(mock);
    }

    [Fact]
    public void WhenItGetsAMoqMockThenItReturnsTheMoqMock()
    {
        var moqMock = new Moq.Mock<object>();

        var mock = Substitute.For<IMock<object>>();
        mock.MoqMock.Returns(moqMock);

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetTheMoq<object>();

        result.Should().Be(moqMock);
    }

    [Fact]
    public void WhenItGetsANamedMockThenItReturnsTheMock()
    {
        var mock = Substitute.For<IMock<object>>();

        var mockName = "MockName";

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>(mockName).Returns(mock);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetTheMock<object>(mockName);

        result.Should().Be(mock);
    }

    [Fact]
    public void WhenItGetsAMockObjectThenItReturnsTheMockObject()
    {
        var obj = new object();

        var mock = Substitute.For<IMock<object>>();
        mock.Object.Returns(obj);

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetTheMockObject<object>();

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsANamedMockObjectThenItReturnsTheMockObject()
    {
        var obj = new object();

        var mockName = "MockName";

        var mock = Substitute.For<IMock<object>>();
        mock.Object.Returns(obj);

        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>(mockName).Returns(mock);

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.GetTheMockObject<object>(mockName);

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsTheSutThenItReturnsTheSut()
    {
        var testSut = new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Sut.Returns(testSut);

        var sut = new VoidAssertion<object>(
            sutArrangement
        );

        var result = sut.Sut;

        result.Should().Be(testSut);
    }
}
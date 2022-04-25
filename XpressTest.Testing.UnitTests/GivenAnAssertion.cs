using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnAssertion
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheResult()
    {
        var obj = new object();
        
        var sut = new Assertion<object, object>(
            obj,
            null
            );

        sut.Result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsAMockThenItGetsTheMockFromTheMockObjectCollection()
    {
        var mock = Substitute.For<IMock<object>>();
        
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.GetTheMock<object>();

        result.Should().Be(mock);
    }
    
    [Fact]
    public void WhenItGetsAMoqMockThenItGetsTheMoqMockFromTheMock()
    {
        var moqMock = new Moq.Mock<object>();
        
        var mock = Substitute.For<IMock<object>>();
        mock.MoqMock.Returns(moqMock);
        
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.GetTheMoq<object>();

        result.Should().Be(moqMock);
    }
    
    [Fact]
    public void WhenItGetsANamedMockThenItGetsTheNamedMockFromTheMockObjectCollection()
    {
        var mockName = "MockName";
        
        var mock = Substitute.For<IMock<object>>();
        
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>(mockName).Returns(mock);
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.GetTheMock<object>(mockName);

        result.Should().Be(mock);
    }
    
    [Fact]
    public void WhenItGetsAMockObjectThenItGetsTheMockObjectFromTheMock()
    {
        var obj = new object();
        
        var mock = Substitute.For<IMock<object>>();
        mock.Object.Returns(obj);
        
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        mockObjectCollection.Get<object>().Returns(mock);
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.GetTheMockObject<object>();

        result.Should().Be(obj);
    }
    
    [Fact]
    public void WhenItGetsTheObjectsThenItGetsTheObjectsFromTheArrangement()
    {
        var objectCollection = Substitute.For<IObjectCollection>();
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Objects.Returns(objectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.Objects;

        result.Should().Be(objectCollection);
    }
    
    [Fact]
    public void WhenItGetsTheMockObjectsThenItGetsTheMockObjectsFromTheArrangement()
    {
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.MockObjects.Returns(mockObjectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.MockObjects;

        result.Should().Be(mockObjectCollection);
    }
    
    [Fact]
    public void WhenItGetsTheDependenciesThenItGetsTheDependenciesFromTheArrangement()
    {
        var dependencyCollection = Substitute.For<IDependencyCollection>();
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Dependencies.Returns(dependencyCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.Dependencies;

        result.Should().Be(dependencyCollection);
    }
    
    [Fact]
    public void WhenItGetsAnObjectThenItGetsTheObjectFromTheObjects()
    {
        var obj = new object();
        
        var objectCollection = Substitute.For<IObjectCollection>();
        objectCollection.Get<object>().Returns(obj);
        
        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.Objects.Returns(objectCollection);
        
        var sut = new Assertion<object, object>(
            null,
            sutArrangement
        );

        var result = sut.GetThe<object>();

        result.Should().Be(obj);
    }
}
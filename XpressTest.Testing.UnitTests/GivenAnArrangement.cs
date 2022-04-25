using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnArrangement
{
    [Fact]
    public void WhenItIsConstructedThenItShouldHaveObjectCollections()
    {
        var objectCollection = Substitute.For<IObjectCollection>();
        var mockObjectCollection = Substitute.For<IMockObjectCollection>();
        var dependencyCollection = Substitute.For<IDependencyCollection>();

        var sut = new Arrangement(
            objectCollection,
            mockObjectCollection,
            dependencyCollection
            );

        sut.Objects.Should().Be(objectCollection);
        sut.MockObjects.Should().Be(mockObjectCollection);
        sut.Dependencies.Should().Be(dependencyCollection);
    }
    
    [Fact]
    public void WhenItGetsAnObjectThenItGetsTheObjectFromTheObjectCollection()
    {
        var obj = new object();
        
        var objectCollection = Substitute.For<IObjectCollection>();
        objectCollection.Get<object>().Returns(obj);
        
        var sut = new Arrangement(
            objectCollection,
            null,
            null
        );

        var result = sut.GetThe<object>();

        result.Should().Be(obj);
    }
    
    [Fact]
    public void WhenItGetsANamedObjectThenItGetsTheObjectFromTheObjectCollection()
    {
        var obj = new object();

        var objName = "ObjName";
        
        var objectCollection = Substitute.For<IObjectCollection>();
        objectCollection.Get<object>(objName).Returns(obj);
        
        var sut = new Arrangement(
            objectCollection,
            null,
            null
        );

        var result = sut.GetThe<object>(objName);

        result.Should().Be(obj);
    }
    
    [Fact]
    public void WhenItAddsAnObjectThenItAddsTheObjectToTheObjectCollection()
    {
        var obj = new object();

        var objectCollection = Substitute.For<IObjectCollection>();
        
        var sut = new Arrangement(
            objectCollection,
            null,
            null
        );

        sut.Add(obj);

        objectCollection.Received(1).Add(obj);
    }
    
    [Fact]
    public void WhenItAddsANamedObjectThenItAddsTheNamedObjectToTheObjectCollection()
    {
        var namedObject = Substitute.For<INamedObject<object>>();

        var objectCollection = Substitute.For<IObjectCollection>();
        
        var sut = new Arrangement(
            objectCollection,
            null,
            null
        );

        sut.Add(namedObject);

        objectCollection.Received(1).Add(namedObject);
    }
    
    [Fact]
    public void WhenItAddsAMockThenItAddsTheMockToTheMockObjects()
    {
        var mock = Substitute.For<IMock<object>>();

        var mockObjects = Substitute.For<IMockObjectCollection>();
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        sut.Add(mock);

        mockObjects.Received(1).Add(mock);
    }
    
    [Fact]
    public void WhenItAddsANamedMockThenItAddsTheNamedMockToTheMockObjects()
    {
        var namedMock = Substitute.For<INamedMock<object>>();

        var mockObjects = Substitute.For<IMockObjectCollection>();
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        sut.Add(namedMock);

        mockObjects.Received(1).Add(namedMock);
    }
    
    [Fact]
    public void WhenItGetsAMockThenItGetsTheMockFromTheMockObjects()
    {
        var mock = Substitute.For<IMock<object>>();

        var mockObjects = Substitute.For<IMockObjectCollection>();
        mockObjects.Get<object>().Returns(mock);
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        var result = sut.GetTheMock<object>();

        result.Should().Be(mock);
    }
    
    [Fact]
    public void WhenItGetsAMoqMockThenItGetsTheMoqMockFromTheMockObjects()
    {
        var moqMock = new Moq.Mock<object>();

        var mock = Substitute.For<IMock<object>>();
        mock.MoqMock.Returns(moqMock);

        var mockObjects = Substitute.For<IMockObjectCollection>();
        mockObjects.Get<object>().Returns(mock);
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        var result = sut.GetTheMoq<object>();

        result.Should().Be(moqMock);
    }
    
    [Fact]
    public void WhenItGetsANamedMockThenItGetsTheNamedMockFromTheMockObjects()
    {
        var mock = Substitute.For<IMock<object>>();

        var mockName = "MockName";
        
        var mockObjects = Substitute.For<IMockObjectCollection>();
        mockObjects.Get<object>(mockName).Returns(mock);
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        var result = sut.GetTheMock<object>(mockName);

        result.Should().Be(mock);
    }
    
    [Fact]
    public void WhenItGetsAMockObjectThenItGetsTheMockObjectFromTheMockObjects()
    {
        var obj = new object();

        var mock = Substitute.For<IMock<object>>();
        mock.Object.Returns(obj);

        var mockObjects = Substitute.For<IMockObjectCollection>();
        mockObjects.Get<object>().Returns(mock);
        
        var sut = new Arrangement(
            null,
            mockObjects,
            null
        );

        var result = sut.GetTheMockObject<object>();

        result.Should().Be(obj);
    }
    
    [Fact]
    public void WhenItAddsADependencyThenItAddsTheDependencyToTheDependencies()
    {
        var dependency = new object();
        
        var dependencies = Substitute.For<IDependencyCollection>();
        
        var sut = new Arrangement(
            null,
            null,
            dependencies
        );

        sut.AddDependency(dependency);
        
        dependencies.Received(1).Add(Arg.Is<IDependency>(d => d.Object == dependency));
    }
    
    [Fact]
    public void WhenItAddsANamedDependencyThenItAddsTheNamedDependencyToTheDependencies()
    {
        var dependency = new object();

        var dependencyName = "DependencyName";
        
        var dependencies = Substitute.For<IDependencyCollection>();
        
        var sut = new Arrangement(
            null,
            null,
            dependencies
        );

        sut.AddDependency(
            dependency,
            dependencyName
            );
        
        dependencies.Received(1).Add(Arg.Is<INamedDependency>(d =>
            d.Object == dependency
            && d.Name == dependencyName));
    }
}
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockObjectCollection
{
    [Fact]
    public void WhenItAddsAMockThenItAddsTheMockToTheCollection()
    {
        var mock = Substitute.For<IMock<object>>();

        var collection = new List<IMock>();

        var sut = new MockObjectCollection(
            null,
            collection
            );

        sut.Add(mock);

        collection.First().Should().Be(mock);
    }

    [Fact]
    public void WhenItAddsANamedMockThenItAddsTheNamedMockToTheCollectionAndDictionary()
    {
        var name = "Name";

        var namedMock = Substitute.For<INamedMock<object>>();
        namedMock.Name.Returns(name);

        var dictionary = new Dictionary<string, IMock>();

        var collection = new List<IMock>();

        var sut = new MockObjectCollection(
            dictionary,
            collection
        );

        sut.Add(namedMock);

        dictionary[name].Should().Be(namedMock);
        collection.First().Should().Be(namedMock);
    }

    [Fact]
    public void WhenItGetsAMockThatHasBeenRegisteredThenItGetsTheMock()
    {
        var mock = Substitute.For<IMock<object>>();

        var collection = new List<IMock>
        {
            mock
        };

        var sut = new MockObjectCollection(
            null,
            collection
        );

        var result = sut.Get<object>();

        result.Should().Be(mock);
    }

    [Fact]
    public void WhenItGetsAMockAndNoMocksHaveBeenRegisteredThenItThrowsMockNotRegisteredException()
    {
        var collection = new List<IMock>();

        var sut = new MockObjectCollection(
            null,
            collection
        );

        var exception = Record.Exception(() => sut.Get<object>());

        exception.Should().BeOfType<MockNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsAMockAndTheMockHasNotBeenRegisteredThenItThrowsMockNotRegisteredException()
    {
        var mock = Substitute.For<IMock<TestObject>>();

        var collection = new List<IMock>
        {
            mock
        };

        var sut = new MockObjectCollection(
            null,
            collection
        );

        var exception = Record.Exception(() => sut.Get<object>());

        exception.Should().BeOfType<MockNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedMockThatHasBeenRegisteredThenItGetsTheNamedMock()
    {
        var name = "Name";

        var namedMock = Substitute.For<INamedMock<object>>();

        var dictionary = new Dictionary<string, IMock>();
        dictionary[name] = namedMock;

        var sut = new MockObjectCollection(
            dictionary,
            null
        );

        var result = sut.Get<object>(name);

        result.Should().Be(namedMock);
    }

    [Fact]
    public void WhenItGetsANamedMockAndNoNamedMocksHaveBeenRegisteredThenItThrowsNamedMockNotRegisteredException()
    {
        var name = "Name";

        var dictionary = new Dictionary<string, IMock>();

        var sut = new MockObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedMockNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedMockAndNoMockWithTheNameHasBeenRegisteredThenItThrowsNamedMockNotRegisteredException()
    {
        var name = "Name";

        var differentName = "DifferentName";

        var namedMock = Substitute.For<INamedMock<object>>();

        var dictionary = new Dictionary<string, IMock>();
        dictionary[differentName] = namedMock;

        var sut = new MockObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedMockNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedMockAndAMockOfADifferentTypeWithTheNameHasBeenRegisteredThenItThrowsNamedMockDifferentTypeRegisteredException()
    {
        var name = "Name";

        var namedMock = Substitute.For<INamedMock<TestObject>>();

        var dictionary = new Dictionary<string, IMock>();
        dictionary[name] = namedMock;

        var sut = new MockObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedMockDifferentTypeRegisteredException<object>>();
    }
}
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnObjectCollection
{
    [Fact]
    public void WhenItGetsAnObjectThatHasBeenRegisteredThenItGetsTheObject()
    {
        var obj = new object();

        var collection = new List<object>
        {
            obj
        };

        var sut = new ObjectCollection(
            null,
            collection
        );

        var result = sut.Get<object>();

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsAnObjectAndNoObjectsHaveBeenRegisteredThenItThrowsObjectNotRegisteredException()
    {
        var collection = new List<object>();

        var sut = new ObjectCollection(
            null,
            collection
        );

        var exception = Record.Exception(() => sut.Get<object>());

        exception.Should().BeOfType<ObjectNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsAnObjectAndTheObjectHasNotBeenRegisteredThenItThrowsObjectNotRegisteredException()
    {
        var obj = new TestClasses.TestObject();

        var collection = new List<object>
        {
            obj
        };

        var sut = new ObjectCollection(
            null,
            collection
        );

        var exception = Record.Exception(() => sut.Get<object>());

        exception.Should().BeOfType<ObjectNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedObjectThatHasBeenRegisteredThenItGetsTheNamedObject()
    {
        var name = "Name";

        var obj = new object();

        var dictionary = new Dictionary<string, object>();
        dictionary[name] = obj;

        var sut = new ObjectCollection(
            dictionary,
            null
        );

        var result = sut.Get<object>(name);

        result.Should().Be(obj);
    }

    [Fact]
    public void WhenItGetsANamedObjectAndNoNamedObjectsHaveBeenRegisteredThenItThrowsNamedObjectNotRegisteredException()
    {
        var name = "Name";

        var dictionary = new Dictionary<string, object>();

        var sut = new ObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedObjectNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedObjectAndNoObjectWithTheNameHasBeenRegisteredThenItThrowsNamedObjectNotRegisteredException()
    {
        var name = "Name";

        var differentName = "DifferentName";

        var namedMock = Substitute.For<INamedObject<object>>();

        var dictionary = new Dictionary<string, object>();
        dictionary[differentName] = namedMock;

        var sut = new ObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedObjectNotRegisteredException<object>>();
    }

    [Fact]
    public void WhenItGetsANamedObjectAndAnObjectOfADifferentTypeWithTheNameHasBeenRegisteredThenItThrowsNamedObjectDifferentTypeRegisteredException()
    {
        var name = "Name";

        var obj = new TestObject();

        var dictionary = new Dictionary<string, object>();
        dictionary[name] = obj;

        var sut = new ObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedObjectDifferentTypeRegisteredException<object>>();
    }

    [Fact]
    public void WhenItAddsAnObjectOfATypeThatHasNotBeenAddedThenItAddsTheObjectToTheCollection()
    {
        var obj = new object();

        var collection = new List<object>();

        var sut = new ObjectCollection(
            null,
            collection
        );

        sut.Add(obj);

        collection.First().Should().Be(obj);
    }

    [Fact]
    public void WhenItAddsAnObjectOfATypeThatHasBeenAddedThenItDoesNotAddTheObjectAndThrowsException()
    {
        var obj = new object();

        var collection = new List<object>
        {
            new object()
        };

        var sut = new ObjectCollection(
            null,
            collection
        );

        var exception = Record.Exception(() => sut.Add(obj));

        exception.Should().BeOfType<UnnamedObjectTypeAlreadyRegisteredException<object>>();

        collection.Count.Should().Be(1);
    }

    [Fact]
    public void WhenItAddsANamedObjectThenItAddsTheNamedObjectToTheDictionary()
    {
        var obj = new object();

        var name = "Name";

        INamedObject<object> namedObject = new NamedObject<object>(
            obj,
            name
            );

        var dictionary = new Dictionary<string, object>();

        var sut = new ObjectCollection(
            dictionary,
            null
        );

        sut.Add(namedObject);

        dictionary[name].Should().Be(obj);
    }
}
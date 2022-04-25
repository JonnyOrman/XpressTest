using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
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

        exception.Should().BeOfType<ObjectNotRegisteredException>();
        exception.Message.Should().Be("No object of type Object registered");
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

        exception.Should().BeOfType<ObjectNotRegisteredException>();
        exception.Message.Should().Be("No object of type Object registered");
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

        exception.Should().BeOfType<NamedObjectNotRegisteredException>();
        exception.Message.Should().Be("No object of type Object with name Name registered");
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

        exception.Should().BeOfType<NamedObjectNotRegisteredException>();
        exception.Message.Should().Be("No object of type Object with name Name registered");
    }
    
    [Fact]
    public void WhenItGetsANamedObjectAndAnObjectOfADifferentTypeWithTheNameHasBeenRegisteredThenItThrowsNamedObjectDifferentTypeRegisteredException()
    {
        var name = "Name";

        var obj = new TestClasses.TestObject();

        var dictionary = new Dictionary<string, object>();
        dictionary[name] = obj;
        
        var sut = new ObjectCollection(
            dictionary,
            null
        );

        var exception = Record.Exception(() => sut.Get<object>(name));

        exception.Should().BeOfType<NamedObjectDifferentTypeRegisteredException>();
        exception.Message.Should().Be("Expected object with name Name is not of type Object");
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

        var exception = Record.Exception(() =>sut.Add(obj));

        exception.Should().BeOfType<UnnamedObjectTypeAlreadyRegisteredException>();
        exception.Message.Should().Be("An unnamed object of type Object has already been registered. Each object of the same type must be registered with a unique name.");
        
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
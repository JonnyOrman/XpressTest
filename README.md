# XpressTest

Write entire unit tests with expressive, fluent syntax:
```cs
[Fact]
public void MultiplyNumbers() =>
    GivenA<Calculator>
        .WhenIt().Multiply(3, 2)
        .ThenTheResultShouldBe(6);

[Fact]
public void DivideByZero() =>
    GivenA<Calculator>
        .WhenIt(sut => sut.Divide(6, 0))
        .ThenItShouldThrow<DivideByZeroException>();
```

Register variables to the test for use in its action and assertion:
```cs
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
            .AndGiven(new EntityParameters("EntityName"))
        .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

Name variables when multiple of the same type are used:
```cs
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
            .AndGiven(new EntityParameters("EntityName"), "ParametersToUse")
            .AndGiven(new EntityParameters("AnotherEntityName"), "SomeOtherParameters")
        .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>("ParametersToUse")))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

Setup and verify mocks:
```cs
[Fact]
public void ProcessValidParameters() =>
    GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty))
            .AndGiven(new Entity(1, string.Empty))
        .WithA<IValidator>()
            .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
            .AndReturns(true)
        .WithA<ICreator>()
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
        .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
        .ThenThe<IValidator>()
            .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
            .Once()
        .ThenThe<ICreator>()
            .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .Once()
        .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
```

## About XpressTest

`XpressTest` is an expressive, fluent testing framework for C# .NET that avoids the need to organise the same, repetitive arrange-act-assert code blocks in every test, and keeps tests free from the clutter of loose variables.

Tests are written by specifying the SUT, registering and setting up any mocks or other objects required for the test case, specifying the action to be tested and then performing assertions on the result and mocks. The SUT is automatically instantiated with a constructor signature matching the registered dependencies.

## Installation

Install to a testing project by running the following:
```
dotnet add package XpressTest --version 1.0.0-beta.1
```

## Writing tests

### Simple tests

Let's test the following `Calculator` class:
```cs
public class Calculator
{
    public int Multiply(int number1, int number2)
    {
        return number1 * number2;
    }

    public int Divide(int number1, int number2)
    {
        return number1 / number2;
    }
}
```

We'll test its `Multiply` method first to verify the correct result is returned when we multiply two numbers.

Begin the arrangement by specifying `Calculator` as the SUT:
```cs
[Fact]
public void MultiplyNumbers() =>
    GivenA<Calculator>
```

Then perform the action of multiplying 3 and 2:
```cs
.WhenIt().Multiply(3, 2)
```

Finally, assert that the result is 6:
```cs
.ThenTheResultShouldBe(6);
```

Let's test the `Divide` method and verify that `DivideByZeroException` is thrown when we divide by 0.

Begin the arrangement by specifying `Calculator` as the SUT:
```cs
[Fact]
public void DivideByZero() =>
    GivenA<Calculator>
```

Then perform the action of dividing 6 by 0:
```cs
.WhenIt(sut => sut.Divide(6, 0))
```

Finally, assert that `DivideByZeroException` was thrown:
```cs
.ThenItShouldThrow<DivideByZeroException>();
```

### Arranging variables

Variables can be arranged for use in the action and assertion.

Consider the following classes:
```cs
public class EntityParameters
{
    public EntityParameters(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}

public class Entity
{
    public Entity(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    
    public string Name { get; }
}

public class Creator
{
    public Entity Create(EntityParameters entityParameters)
    {
        var nextId = 1;
        
        return new Entity(
            nextId,
            entityParameters.Name);
    }
}
```

Let's test the `Create` method on the `Creator` class and verify that, when an `Entity` is created from some `EntityParameters`, an `Entity` with the expected `Id` and `Name` is returned.

Begin the arrangement by specifying `Creator` as the SUT:
```cs
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
```

Next we will arrange the `EntityParameters` that we want to use in the test:
```cs
.AndGiven(new EntityParameters("EntityName"))
```

Then we will perform the `Create` action with the `EntityParameters` we arranged:
```cs
.WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
```

Finally, verify that the returned `Entity` is as expected, first by verifying the `Id`:
```cs
.ThenTheResult(result => result.Id).ShouldBe(1)
```

And then by verifying the `Name`:
```cs
.ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

### Mocks and dependencies

Consider the following classes and interfaces:
```cs
public class EntityParameters
{
    public EntityParameters(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}

public class Entity
{
    public Entity(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    
    public string Name { get; }
}

public interface IValidator
{
    bool IsValid(EntityParameters entityParameters);
}

public interface ICreator
{
    Entity Create(EntityParameters entityParameters);
}

public class ParametersProcessor
{
    private readonly IValidator _validator;
    private readonly ICreator _creator;

    public ParametersProcessor(
        IValidator validator,
        ICreator creator
    )
    {
        _validator = validator;
        _creator = creator;
    }

    public Entity Process(EntityParameters entityParameters)
    {
        if(_validator.IsValid(entityParameters))
        {
            return _creator.Create(entityParameters);
        }

        return null;
    }
}
```

The `ParametersProcessor` class has a `Process` method that validates the provided `EntityParameters` and creates an `Entity` from it if it is valid.

To test `ParametersProcessor` we need to provide the `IValidator` and `ICreator` dependencies to it and set them up accordingly for the test scenario we want to cover.

Let's test a scenario where the `IValidator` finds the `EntityParameters` provided to be valid and then the `ICreator` creates an `Entity` from it.

Begin the arrangement by specifying `ParametersProcessor` as the SUT:
```cs
[Fact]
public void ProcessValidParameters() =>
    GivenA<ParametersProcessor>
```

Next we will arrange the `EntityParameters` and `Entity` that we want to use in the test:
```cs
.AndGiven(new EntityParameters(string.Empty))
.AndGiven(new Entity(1, string.Empty))
```

We will then provide mocks of the `IValidator` and `ICreator` dependencies that `ParametersProcessor` has, setting up the `IValidator` so that it returns `true` when it validates the `EntityParameters`, and setting up the `ICreator` so that it returns the `Entity` when it creates an entity from the `EntityParameters`:
```cs
.WithA<IValidator>()
    .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
    .AndReturns(true)
.WithA<ICreator>()
    .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
    .AndReturns(arrangement => arrangement.GetThe<Entity>())
```

Then we will perform the `Process` action with the `EntityParameters` we arranged:
```cs
.WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
```

We can now verify that the `IValidator` and `ICreator` were called as expected:
```cs
.ThenThe<IValidator>()
    .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
    .Once()
.ThenThe<ICreator>()
    .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
    .Once()
```

Finally, verify that the returned `Entity` is as expected:
```cs
.ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
```

## More examples

Many more different types of test scenarios are possible with `XpressTest`. See the [XpressTest.Examples](https://github.com/JonnyOrman/XpressTest/tree/main/XpressTest.Examples/Tests) project in this repository for more examples.

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

See the [XpressTest.Examples](https://github.com/JonnyOrman/XpressTest/tree/main/XpressTest.Examples/Tests) project in this repository for many more examples.

## About XpressTest

`XpressTest` is an expressive, fluent testing framework for C# .NET that avoids the need to organise the same, repetitive arrange-act-assert code blocks in every test, and keeps tests free from the clutter of loose variables.

Tests are written by specifying the SUT, registering and setting up any mocks or other objects required for the test case, specifying the action to be tested and then performing assertions on the result and mocks. The SUT is automatically instantiated with a constructor signature matching the registered dependencies.

## Installation

Install to a testing project by running the following:
```
dotnet add package XpressTest --version 1.0.0-beta.1
```
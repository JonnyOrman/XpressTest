# XpressTest
`XpressTest` is a fluent testing framework for C# .NET that avoids the need to organise the same, repetitive arrange-act-assert code blocks in every test, and keeps tests free from the clutter of loose variables.

Tests are written by specifying the SUT, registering and setting up any mocks or other objects required for the test case, specifying the action to be tested and then performing assertions on the result and mocks. The SUT is automatically instantiated with the registered dependencies.

Simple tests written with `XpressTest` look like this:
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

Each test has its own state that allows you to register variables during arrangement. These variables can then be used in the action and assertment:
```cs
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
        .AndGiven(new EntityParameters("EntityName"))
        .WhenIt(action => action.Sut.Create(action.GetObject<EntityParameters>()))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

Variables can be given names to identify them if multiple of the same type are registered:
```cs
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
        .AndGiven(new EntityParameters("EntityName"), "ParametersToUse")
        .AndGiven(new EntityParameters("AnotherEntityName"), "SomeOtherParameters")
        .WhenIt(action => action.Sut.Create(action.GetObject<EntityParameters>("ParametersToUse")))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

Mocks can be set up and verified:
```cs
public void ProcessValidParameters() =>
    GivenA<ParametersProcessor>
        .AndGiven(new EntityParameters(string.Empty))
        .AndGiven(new Entity(1, string.Empty))
        .WithA<IValidator>()
            .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>()))
            .AndReturns(true)
        .WithA<ICreator>()
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetObject<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetObject<Entity>())
        .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>()))
        .Then<IValidator>().Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>())).Once()
        .Then<ICreator>().Should<Entity>(arrangement => creator => creator.Create(arrangement.GetObject<EntityParameters>())).Once()
        .ThenTheResultShouldBe(arrangement => arrangement.GetObject<Entity>());
```

## Getting started

Install by running the following:
```
dotnet add package XpressTest --version 1.0.0-alpha.9
```

Examples of usage can be seen in the `XpressTest.Examples` project in this repository.

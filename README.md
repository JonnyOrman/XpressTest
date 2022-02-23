# XpressTest
`XpressTest` is a testing framework that allows you to easily write well structured tests in a consistent given-when-then format. It avoids common, repetitive tasks often involved in writing tests such as instantiating the SUT (System Under Test), and it saves your tests from being cluttered with loose variables.

Tests are written by specifying the SUT, arranging any mocks or other objects required for the test case, specifying the action to be tested and then performing an assertion on the result and mocks.

Simple tests written with `XpressTest` will look something like this:
```
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
```
[Fact]
public void CreateEntity() =>
    GivenA<Creator>
        .AndGiven(new EntityParameters("EntityName"))
        .WhenIt(action => action.Sut.Create(action.GetObject<EntityParameters>()))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

Variables can be given names to identify them if multiple of the same type are registered:
```
[Fact]
public void CreateEntity_Example2() =>
    GivenA<Creator>
        .AndGiven(new EntityParameters("EntityName"), "ParametersToUse")
        .AndGiven(new EntityParameters("AnotherEntityName"), "SomeOtherParameters")
        .WhenIt(action => action.Sut.Create(action.GetObject<EntityParameters>("ParametersToUse")))
        .ThenTheResult(result => result.Id).ShouldBe(1)
        .ThenTheResult(result => result.Name).ShouldBe("EntityName");
```

More complex setups and assertions including mocks are possible:
```
[Fact]
public void ProcessValidParameters() =>
    GivenA<ParametersProcessor>
        .AndGiven(new EntityParameters(string.Empty), "parameters")
        .AndGiven(new Entity(1, string.Empty), "entity")
        .WithA<IValidator>()
        .ThatDoes(arrangement =>
            new MockSetup<IValidator, bool>(
                validator => validator.IsValid(arrangement.GetObject<EntityParameters>("parameters")),
                true))
        .WithA<ICreator>()
        .ThatDoes(arrangement =>
            new MockSetup<ICreator, Entity>(
                creator => creator.Create(arrangement.GetObject<EntityParameters>("parameters")),
                arrangement.Objects.Get<Entity>("entity")
            ))
        .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>("parameters")))
        .Then(assertion =>
        {
            assertion.Dependencies.GetMock<IValidator>()
                .Verify(validator => validator.IsValid(assertion.GetObject<EntityParameters>("parameters")),
                    Times.Once);
            assertion.Dependencies.GetMock<ICreator>()
                .Verify(
                    creator => creator.Create(assertion.GetObject<EntityParameters>("parameters")),
                    Times.Once);
            Assert.Equal(assertion.GetObject<Entity>("entity"), assertion.Result);
        })
        .Test();
```

## Getting started

Install by running the following:
```
dotnet add package XpressTest --version 1.0.0-alpha.7
```

Examples of usage can be seen in the `XpressTest.Examples` project in this repository.
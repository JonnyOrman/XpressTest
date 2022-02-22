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
public void DivideNumbers() =>
    GivenA<Calculator>
        .WhenIt().Divide(6, 3)
        .ThenTheResultShouldBe(2);

[Fact]
public void DivideByZero() =>
    GivenA<Calculator>
        .WhenIt(sut => sut.Divide(6, 0))
        .ThenItShouldThrow<DivideByZeroException>();
```

Tests that require more detailed setup and assertion will look something like this:
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
        .ThenItShould(assertion =>
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
dotnet add package XpressTest --version 1.0.0-alpha.5
```

Examples of usage can be seen in the `XpressTest.Examples` project in this repository.
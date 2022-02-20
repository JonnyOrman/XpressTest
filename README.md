# XpressTest
`XpressTest` is a testing framework that allows you to easily write well structured tests in a consistent given-when-then format. It avoids common, repetitive tasks often involved in writing tests such as instantiating the SUT (System Under Test), and it saves your tests from being cluttered with loose variables.

Tests are written by specifying the SUT, arranging any mocks or other objects required for the test case, specifying the action to be tested and then performing an assertion on the result and mocks.

Tests written with `XpressTest` will look something like this:
```
[Fact]
public void AddsNumbers =>
    GivenA<Calculator>
        .WhenIt(action => action.Sut.Add(2, 2))
        .ThenItShould(assertion => { Assert.Equal(4, assertion.Result); })
        .Test();
```

## Getting started

Install by running the following:
```
dotnet add package XpressTest --version 1.0.0-alpha.3
```

Also install a testing framework such as Xunit:
```
dotnet add package xunit
```

If we have the following classes and interfaces:
```
namespace XpressTest.Examples;

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

public class EntityParameters
{
    public EntityParameters(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}

public interface IValidator
{
    bool IsValid(EntityParameters entityParameters);
}

public class Validator : IValidator
{
    public bool IsValid(EntityParameters entityParameters)
    {
        return !string.IsNullOrWhiteSpace(entityParameters.Name);
    }
}

public interface ICreator
{
    Entity Create(EntityParameters entityParameters);
}

public class Creator : ICreator
{
    public Entity Create(EntityParameters entityParameters)
    {
        var nextId = 1;
        
        return new Entity(
            1,
            entityParameters.Name);
    }
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

Then we can test them like this:
```
using Moq;
using Xunit;

namespace XpressTest.Examples;

public class ValidatorTests
{
    [Theory]
    [InlineData("ValidName", true)]
    [InlineData(" ", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ValidateParameters(string name, bool expectedResult) =>
        GivenA<Validator>
            .And(new EntityParameters(name), "EntityParameters")
            .WhenIt(action => action.Sut.IsValid(action.Objects.Get<EntityParameters>("EntityParameters")))
            .ThenItShould(assertion => { Assert.Equal(expectedResult, assertion.Result); })
            .Test();
}

public class CreatorTests
{
    [Fact]
    public void CreateEntity() =>
        GivenA<Creator>
            .And(new EntityParameters("EntityName"), "EntityParameters")
            .WhenIt(action => action.Sut.Create(action.Objects.Get<EntityParameters>("EntityParameters")))
            .ThenItShould(assertion =>
            {
                Assert.Equal(1, assertion.Result.Id);
                Assert.Equal("EntityName", assertion.Result.Name);
            })
            .Test();
}

public class ParametersProcessorTests
{
    [Fact]
    public void ProcessValidParameters() =>
        GivenA<ParametersProcessor>
            .And(new EntityParameters(string.Empty), "parameters")
            .And(new Entity(1, string.Empty), "entity")
            .WithA<IValidator>()
            .That(arrangement =>
                new MockSetup<IValidator, bool>(
                    validator => validator.IsValid(arrangement.Objects.Get<EntityParameters>("parameters")),
                    true))
            .WithA<ICreator>()
            .That(arrangement =>
                new MockSetup<ICreator, Entity>(
                    creator => creator.Create(arrangement.Objects.Get<EntityParameters>("parameters")),
                    arrangement.Objects.Get<Entity>("entity")
                ))
            .WhenIt(action => action.Sut.Process(action.Objects.Get<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(validator => validator.IsValid(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                Assert.Equal(assertion.Objects.Get<Entity>("entity"), assertion.Result);
            })
            .Test();

    [Fact]
    public void ProcessInvalidParameters() =>
        GivenA<ParametersProcessor>
            .And(new EntityParameters(string.Empty), "parameters")
            .WithA<IValidator>()
            .That(arrangement => new MockSetup<IValidator, bool>(
                validator => validator.IsValid(arrangement.Objects.Get<EntityParameters>("parameters")),
                false))
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.Objects.Get<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(
                        validator => validator.IsValid(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(It.IsAny<EntityParameters>()),
                        Times.Never);
                Assert.Null(assertion.Result);
            })
            .Test();
}
```

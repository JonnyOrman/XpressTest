# XpressTest
Write expressive and fluent tests in .NET

## Quick start

Install by running the following:
```
dotnet add package XpressTest --version 1.0.0-alpha.2
```

Also install a testing framework such as Xunit:
```
dotnet add package xunit
```

If we have the following classes and interfaces:
```
namespace XpressTestExample;

public class Entity {}

public class EntityParameters {}

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

Then we can test the `ParametersProcessor` class like this:
```
using XpressTest;
using Xunit;

namespace XpressTestExample;

public class Tests
{
    private EntityParameters _entityParameters;

    private Entity _entity;

    public Tests()
    {
        _entityParameters = new EntityParameters();
        _entity = new Entity();
    }

    [Fact]
    public void ValidParameters() =>
        GivenA<ParametersProcessor>
            .WithA<IValidator>()
                .That(validator => validator.IsValid(_entityParameters), true)
            .WithA<ICreator>()
                .That(creator => creator.Create(_entityParameters), _entity)
            .WhenIt(sut => sut.Process(_entityParameters))
            .ThenItShould(result => {
                Assert.Equal(_entity, result);
            })
            .Test();

    [Fact]
    public void InvalidParameters() =>
        GivenA<ParametersProcessor>
            .WithA<IValidator>()
                .That(validator => validator.IsValid(_entityParameters), false)
            .WithA<ICreator>()
            .WhenIt(sut => sut.Process(_entityParameters))
            .ThenItShould(result => {
                Assert.Null(result);
            })
            .Test();
}
```
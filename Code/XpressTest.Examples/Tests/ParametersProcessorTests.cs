using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorTests
{
    [Fact]
    public void ProcessValidParameters_Example1() =>
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

    [Fact]
    public void ProcessValidParameters_Example2()
    {
        var entityParameters = new EntityParameters(string.Empty);

        var entity = new Entity(1, string.Empty);

        GivenA<ParametersProcessor>
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(true)
            .WithA<ICreator>()
                .ThatDoes(creator => creator.Create(entityParameters))
                .AndReturns(entity)
            .WhenIt(sut => sut.Process(entityParameters))
            .ThenThe<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .ThenThe<ICreator>()
                .Should(creator => creator.Create(entityParameters))
                .Once()
            .ThenTheResultShouldBe(entity);
    }

    [Fact]
    public void ProcessValidParameters_Example3()
    {
        var entityParameters = new EntityParameters(string.Empty);

        var entity = new Entity(1, string.Empty);

        GivenA<ParametersProcessor>
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(true)
            .WithA<ICreator>()
                .ThatDoes(creator => creator.Create(entityParameters))
                .AndReturns(entity)
            .WhenIt(sut => sut.Process(entityParameters))
            .Then(assertion =>
            {
                assertion.GetTheMoq<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetTheMoq<ICreator>().Verify(creator => creator.Create(entityParameters), Times.Once);
                Assert.Equal(entity, assertion.Result);
            });
    }

    [Fact]
    public void ProcessValidParameters_Example4() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty))
                .AndGiven(new Entity(1, string.Empty))
                .AndGivenA<ICreator>()
                    .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                    .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WithA<IValidator>("Validator")
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(true)
            .WithTheMock<ICreator>()
            .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenThe<IValidator>("Validator")
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenThe<ICreator>()
                .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());

    [Fact]
    public void ProcessValidParameters_Example5() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty), "EntityParameters")
                .AndGiven(new Entity(1, string.Empty), "Entity")
            .WithA<IValidator>("Validator")
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>("EntityParameters")))
                .AndReturns(true)
            .WithA<ICreator>("Creator")
                .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>("EntityParameters")))
                .AndReturns(arrangement => arrangement.GetThe<Entity>("Entity"))
            .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>("EntityParameters")))
            .ThenThe<IValidator>("Validator")
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>("EntityParameters")))
                .Once()
            .ThenThe<ICreator>("Creator")
                .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>("EntityParameters")))
                .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>("Entity"));

    [Fact]
    public void ProcessValidParameters_Example6() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty))
                .AndGiven(new Entity(1, string.Empty))
            .WithA<IValidator>("Validator")
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(true)
            .WithA<ICreator>("Creator")
                .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenThe<IValidator>("Validator")
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenThe<ICreator>("Creator")
                .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());

    [Fact]
    public void ProcessValidParameters_Example7() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty))
                .AndGiven(new Entity(1, string.Empty))
                .AndGivenA<ICreator>()
                    .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                    .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WithA<IValidator>()
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(true)
            .WithTheMock<ICreator>()
            .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenThe<IValidator>()
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenThe<ICreator>()
                .Should<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());

    [Fact]
    public void ProcessInvalidParameters_Example1() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty))
            .WithA<IValidator>()
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenThe<IValidator>()
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenThe<ICreator>()
                .Should(creator => creator.Create(It.IsAny<EntityParameters>()))
                .Never()
            .ThenTheResultShouldBeNull();

    [Fact]
    public void ProcessInvalidParameters_Example2()
    {
        var entityParameters = new EntityParameters(string.Empty);

        GivenA<ParametersProcessor>
                .AndGiven(entityParameters)
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(sut => sut.Process(entityParameters))
            .ThenThe<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .ThenThe<ICreator>()
                .Should(creator => creator.Create(It.IsAny<EntityParameters>()))
                .Never()
            .ThenTheResultShouldBeNull();
    }

    [Fact]
    public void ProcessInvalidParameters_Example3()
    {
        var entityParameters = new EntityParameters(string.Empty);

        GivenA<ParametersProcessor>
                .AndGiven(entityParameters)
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(sut => sut.Process(entityParameters))
            .Then(assertion =>
            {
                assertion.GetTheMoq<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetTheMoq<ICreator>().Verify(creator => creator.Create(It.IsAny<EntityParameters>()), Times.Never);
                Assert.Null(assertion.Result);
            });
    }
}
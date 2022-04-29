using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorAsyncTests
{
    [Fact]
    public void ProcessValidParametersAsync_Example1() =>
        GivenA<ParametersProcessorAsync>
                .AndGiven(new EntityParameters(string.Empty))
                .AndGiven(new Entity(1, string.Empty))
            .WithA<IValidator>()
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(true)
            .WithA<ICreatorAsync>()
                .ThatDoesAsync<Entity>(arrangement => creator => creator.CreateAsync(arrangement.GetThe<EntityParameters>()))
                .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WhenItAsync(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenTheAsync<IValidator>()
                .Should(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheAsync<ICreatorAsync>()
                .Should(arrangement => creator => creator.CreateAsync(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());

    [Fact]
    public void ProcessValidParametersAsync_Example2()
    {
        var entityParameters = new EntityParameters(string.Empty);

        var entity = new Entity(1, string.Empty);

        GivenA<ParametersProcessorAsync>
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(true)
            .WithA<ICreatorAsync>()
                .ThatDoesAsync(creator => creator.CreateAsync(entityParameters))
                .AndReturns(entity)
            .WhenItAsync(sut => sut.Process(entityParameters))
            .ThenTheAsync<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .ThenTheAsync<ICreatorAsync>()
                .Should(creator => creator.CreateAsync(entityParameters))
                .Once()
            .ThenTheResultShouldBe(entity);
    }

    [Fact]
    public void ProcessValidParametersAsync_Example3()
    {
        var entityParameters = new EntityParameters(string.Empty);

        var entity = new Entity(1, string.Empty);

        GivenA<ParametersProcessorAsync>
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(true)
            .WithA<ICreatorAsync>()
                .ThatDoesAsync(creator => creator.CreateAsync(entityParameters))
                .AndReturns(entity)
            .WhenItAsync(sut => sut.Process(entityParameters))
            .ThenAsync(assertion =>
            {
                assertion.GetTheMoq<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetTheMoq<ICreatorAsync>().Verify(creator => creator.CreateAsync(entityParameters), Times.Once);
                Assert.Equal(entity, assertion.Result);
            });
    }

    [Fact]
    public void ProcessInvalidParametersAsync_Example1() =>
        GivenA<ParametersProcessorAsync>
                .AndGiven(new EntityParameters(string.Empty))
            .WithA<IValidator>()
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(false)
            .WithA<ICreatorAsync>()
            .WhenItAsync(arrangement => arrangement.Sut.Process(arrangement.GetThe<EntityParameters>()))
            .ThenTheAsync<IValidator>()
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .ThenTheAsync<ICreatorAsync>()
                .Should(creator => creator.CreateAsync(It.IsAny<EntityParameters>()))
                .Never()
            .ThenTheResultShouldBeNull();

    [Fact]
    public void ProcessInvalidParametersAsync_Example2()
    {
        var entityParameters = new EntityParameters(string.Empty);

        GivenA<ParametersProcessorAsync>
                .AndGiven(entityParameters)
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(false)
            .WithA<ICreatorAsync>()
            .WhenItAsync(sut => sut.Process(entityParameters))
            .ThenTheAsync<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .ThenTheAsync<ICreatorAsync>()
                .Should(creator => creator.CreateAsync(It.IsAny<EntityParameters>()))
                .Never()
            .ThenTheResultShouldBeNull();
    }

    [Fact]
    public void ProcessInvalidParametersAsync_Example3()
    {
        var entityParameters = new EntityParameters(string.Empty);

        GivenA<ParametersProcessorAsync>
                .AndGiven(entityParameters)
            .WithA<IValidator>()
                .ThatDoes(validator => validator.IsValid(entityParameters))
                .AndReturns(false)
            .WithA<ICreatorAsync>()
            .WhenItAsync(sut => sut.Process(entityParameters))
            .ThenAsync(assertion =>
            {
                assertion.GetTheMoq<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetTheMoq<ICreatorAsync>().Verify(creator => creator.CreateAsync(It.IsAny<EntityParameters>()), Times.Never);
                Assert.Null(assertion.Result);
            });
    }
}
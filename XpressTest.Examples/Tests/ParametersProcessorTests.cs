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
            .WhenIt(action => action.Sut.Process(action.GetThe<EntityParameters>()))
            .Then<IValidator>()
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .Then<ICreator>()
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
            .Then<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .Then<ICreator>()
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
                assertion.GetMock<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetMock<ICreator>().Verify(creator => creator.Create(entityParameters), Times.Once);
                Assert.Equal(entity, assertion.Result);
            });
    }

    [Fact]
    public void ProcessInvalidParameters_Example1() =>
        GivenA<ParametersProcessor>
                .AndGiven(new EntityParameters(string.Empty))
            .WithA<IValidator>()                                                                                                                                                                            
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.GetThe<EntityParameters>()))
            .Then<IValidator>()
                .Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetThe<EntityParameters>()))
                .Once()
            .Then<ICreator>()
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
            .Then<IValidator>()
                .Should(validator => validator.IsValid(entityParameters))
                .Once()
            .Then<ICreator>()
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
                assertion.GetMock<IValidator>().Verify(validator => validator.IsValid(entityParameters), Times.Once);
                assertion.GetMock<ICreator>().Verify(creator => creator.Create(It.IsAny<EntityParameters>()), Times.Never);
                Assert.Null(assertion.Result);
            });
    }
}
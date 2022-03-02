using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorTests
{
    [Fact]
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
            
    [Fact]
    public void ProcessInvalidParameters() =>
        GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty))
            .WithA<IValidator>()                                                                                                                                                                            
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>()))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>()))
            .Then<IValidator>().Should<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>())).Once()
            .Then<ICreator>().Should(creator => creator.Create(It.IsAny<EntityParameters>())).Never()
            .ThenTheResultShouldBeNull();
}
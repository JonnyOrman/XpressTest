using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ConditionalCreatorTests
{
    [Fact]
    public void UseCreatorA_Example1() =>
        GivenA<ConditionalCreator>
            .AndGiven(new EntityParameters("EntityName"))
            .AndGiven(new Entity(1, "EntityName"))
            .With(new ConditionalCreatorSettings(true))
            .WithA<ICreator>("CreatorA")
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WithA<ICreator>("CreatorB")
            .WhenIt(action => action.Sut.Create(action.GetThe<EntityParameters>()))
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
    
    [Fact]
    public void UseCreatorA_Example2() =>
        GivenA<ConditionalCreator>
            .AndGiven(new EntityParameters("EntityName"))
            .AndGiven(new Entity(1, "EntityName"))
            .With(new ConditionalCreatorSettings(true))
            .WithA<ICreator>("CreatorA")
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WithA<ICreator>("CreatorB")
            .WhenIt(action => action.Sut.Create(action.GetThe<EntityParameters>()))
            .Then<ICreator>("CreatorA")
            .Should(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .Once()
            .Then<ICreator>("CreatorB")
            .Should(creator => creator.Create(It.IsAny<EntityParameters>()))
            .Never()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
    
    [Fact]
    public void UseCreatorA_Example3() =>
        GivenA<ConditionalCreator>
            .AndGiven(new EntityParameters("EntityName"))
            .AndGiven(new Entity(1, "EntityName"))
            .With(new ConditionalCreatorSettings(true))
            .WithA<ICreator>()
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WithA<ICreator>("CreatorB")
            .WhenIt(action => action.Sut.Create(action.GetThe<EntityParameters>()))
            .Then<ICreator>()
            .Should(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .Once()
            .Then<ICreator>("CreatorB")
            .Should(creator => creator.Create(It.IsAny<EntityParameters>()))
            .Never()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
    
    [Fact]
    public void UseCreatorB_Example1() =>
        GivenA<ConditionalCreator>
            .AndGiven(new EntityParameters("EntityName"))
            .AndGiven(new Entity(1, "EntityName"))
            .With(new ConditionalCreatorSettings(false))
            .WithA<ICreator>("CreatorA")
            .WithA<ICreator>("CreatorB")
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WhenIt(action => action.Sut.Create(action.GetThe<EntityParameters>()))
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
    
    [Fact]
    public void UseCreatorB_Example2() =>
        GivenA<ConditionalCreator>
            .AndGiven(new EntityParameters("EntityName"))
            .AndGiven(new Entity(1, "EntityName"))
            .With(new ConditionalCreatorSettings(false))
            .WithA<ICreator>("CreatorA")
            .WithA<ICreator>("CreatorB")
            .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .AndReturns(arrangement => arrangement.GetThe<Entity>())
            .WhenIt(action => action.Sut.Create(action.GetThe<EntityParameters>()))
            .Then<ICreator>("CreatorA")
            .Should(creator => creator.Create(It.IsAny<EntityParameters>()))
            .Never()
            .Then<ICreator>("CreatorB")
            .Should(arrangement => creator => creator.Create(arrangement.GetThe<EntityParameters>()))
            .Once()
            .ThenTheResultShouldBe(arrangement => arrangement.GetThe<Entity>());
}
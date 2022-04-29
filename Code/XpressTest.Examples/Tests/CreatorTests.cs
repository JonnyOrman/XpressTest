using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class CreatorTests
{
    [Fact]
    public void CreateEntity_Example1() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters("EntityName"))
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBe("EntityName");

    [Fact]
    public void CreateEntity_Example2() =>
        GivenA<Creator>
                .AndGiven("EntityName")
                .AndGiven(arrangement => new EntityParameters(arrangement.GetThe<string>()))
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBe("EntityName");

    [Fact]
    public void CreateEntity_Example3() =>
        GivenA<Creator>
                .AndGiven("EntityName", "EntityNameToUse")
                .AndGiven("AnotherEntityName", "SomeOtherEntityName")
                .AndGiven(arrangement => new EntityParameters(arrangement.GetThe<string>("EntityNameToUse")), "ParametersToUse")
                .AndGiven(arrangement => new EntityParameters(arrangement.GetThe<string>("SomeOtherEntityName")), "SomeOtherParameters")
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>("ParametersToUse")))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>("EntityNameToUse"));

    [Fact]
    public void CreateEntity_Example4() =>
        GivenA<Creator>
                .AndGiven("EntityName", "EntityNameToUse")
                .AndGiven("AnotherEntityName", "SomeOtherEntityName")
                .AndGiven(arrangement => new EntityParameters(arrangement.GetThe<string>("EntityNameToUse")), "ParametersToUse")
                .AndGiven(arrangement => new EntityParameters(arrangement.GetThe<string>("SomeOtherEntityName")), "SomeOtherParameters")
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>("ParametersToUse")))
            .ThenTheResult(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>("EntityNameToUse"))
            .ThenTheResult(result => result.Id).ShouldBe(1);

    [Fact]
    public void CreateEntity_Example5() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters("EntityName"), "ParametersToUse")
                .AndGiven(new EntityParameters("AnotherEntityName"), "SomeOtherParameters")
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>("ParametersToUse")))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBe("EntityName");

    [Fact]
    public void CreateEntity_Example6() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters("EntityName"), "EntityParametersToUse")
                .AndGiven(new EntityParameters("AnotherEntityName"), "SomeOtherEntityParameters")
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>("EntityParametersToUse")))
            .Then(assertion =>
            {
                Assert.Equal(1, assertion.Result.Id);
                Assert.Equal("EntityName", assertion.Result.Name);
            });

    [Fact]
    public void CreateEntity_Example7()
    {
        var parameters = new EntityParameters("EntityName");

        var entity = new Entity(1, "EntityName");

        GivenA<Creator>
            .WhenIt().Create(parameters)
            .ThenTheResultShouldBeEquivalentTo(entity);
    }

    [Fact]
    public void CreateEntity_Example8() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters("EntityName"))
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResultShouldNotBeNull();

    [Fact]
    public void CreateEntity_Example9() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters("EntityName"))
            .WhenIt<Entity>(arrangement => sut => sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBe("EntityName");

    [Fact]
    public void CreateEntity_NullProperty_Example1() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters(null))
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResult(result => result.Id).ShouldBe(1)
            .ThenTheResult(result => result.Name).ShouldBeNull();

    [Fact]
    public void CreateEntity_NullProperty_Example2() =>
        GivenA<Creator>
                .AndGiven(new EntityParameters(null))
            .WhenIt(arrangement => arrangement.Sut.Create(arrangement.GetThe<EntityParameters>()))
            .ThenTheResult(result => result.Name).ShouldBeNull()
            .ThenTheResult(result => result.Id).ShouldBe(1);
}
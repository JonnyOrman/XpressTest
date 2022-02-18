using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

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
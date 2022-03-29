using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class EntityTests
{
    [Fact]
    public void ConstructsEntity() =>
        GivenA<Entity>
            .WithValue(123)
            .With("MyEntity")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");
}
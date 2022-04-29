using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class EntityTests
{
    [Fact]
    public void ConstructsEntity_Example1() =>
        GivenA<Entity>
            .With(123)
            .With("MyEntity")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");

    [Fact]
    public void ConstructsEntity_Example2() =>
        GivenA<Entity>
                .AndGiven(123)
                .AndGiven("MyEntity")
            .WithThe<int>()
            .WithThe<string>()
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");

    [Fact]
    public void ConstructsEntity_Example3() =>
        GivenA<Entity>
                .AndGiven(123)
                .AndGiven("MyEntity")
            .WithThe<int>()
            .WithThe<string>()
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(arrangement => arrangement.GetThe<int>())
            .ThenIts(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>());

    [Fact]
    public void ConstructsEntity_Example4() =>
        GivenA<Entity>
                .AndGiven(123, "Id")
                .AndGiven("MyEntity", "Name")
            .WithThe<int>("Id")
            .WithThe<string>("Name")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");

    [Fact]
    public void ConstructsEntity_Example5() =>
        GivenA<Entity>
                .AndGiven(123, "Id")
                .AndGiven("MyEntity", "Name")
            .WithThe<int>("Id")
            .WithThe<string>("Name")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(arrangement => arrangement.GetThe<int>("Id"))
            .ThenIts(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>("Name"));

    [Fact]
    public void ConstructsEntity_Example6() =>
        GivenA<Entity>
                .AndGiven(123, "Id")
                .AndGiven("MyEntity")
            .WithThe<int>("Id")
            .WithThe<string>()
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(arrangement => arrangement.GetThe<int>("Id"))
            .ThenIts(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>());

    [Fact]
    public void ConstructsEntity_Example7() =>
        GivenA<Entity>
                .AndGiven(123)
                .AndGiven("MyEntity", "Name")
            .WithThe<int>()
            .WithThe<string>("Name")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(arrangement => arrangement.GetThe<int>())
            .ThenIts(result => result.Name).ShouldBe(arrangement => arrangement.GetThe<string>("Name"));

    [Fact]
    public void ConstructsEntity_Example8() =>
        GivenA<Entity>
                .AndGiven<string>("MyEntity")
            .With(123)
            .WithThe<string>()
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");

    [Fact]
    public void ConstructsEntity_Example9() =>
        GivenA<Entity>
            .With(123)
            .With<string>("MyEntity", "Name")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");

    [Fact]
    public void ConstructsEntity_Example10() =>
        GivenA<Entity>
            .With(123, "Id")
            .With<string>("MyEntity")
            .WhenItIsConstructed()
            .ThenIts(result => result.Id).ShouldBe(123)
            .ThenIts(result => result.Name).ShouldBe("MyEntity");
}
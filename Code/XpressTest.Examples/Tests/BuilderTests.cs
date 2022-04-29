using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class BuilderTests
{
    [Fact]
    public void BuildItems_Example1() =>
        GivenA<Builder>
                .AndGiven(new BuilderItem("a"), "BuilderItem1")
                .AndGiven(new BuilderItem("b"), "BuilderItem2")
                .AndGiven(new BuilderItem("c"), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void BuildItems_Example2() =>
        GivenA<Builder>
            .AndGivenA<IBuilderItem>("BuilderItem1")
                .ThatDoes(builderItem => builderItem.GetValue())
                .AndReturns("a")
            .AndGivenA<IBuilderItem>("BuilderItem2")
                .ThatDoes(builderItem => builderItem.GetValue())
                .AndReturns("b")
            .AndGivenA<IBuilderItem>("BuilderItem3")
                .ThatDoes(builderItem => builderItem.GetValue())
                .AndReturns("c")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetTheMockObject<IBuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetTheMockObject<IBuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetTheMockObject<IBuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void BuildItems_Example3() =>
        GivenA<Builder>
                .AndGiven(new BuilderItem("a"), "BuilderItem1")
                .AndGiven(new BuilderItem("b"), "BuilderItem2")
                .AndGiven(new BuilderItem("c"), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBeA<string>();

    [Fact]
    public void BuildItems_Example4() =>
        GivenA<Builder>
                .AndGiven(new BuilderItem("a"))
                .AndGiven(new BuilderItem("b"), "BuilderItem2")
                .AndGiven(new BuilderItem("c"), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>()))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBeA<string>();

    [Fact]
    public void BuildItems_Example5() =>
        GivenA<Builder>
                .AndGiven(new BuilderItem("a"), "BuilderItem1")
                .AndGiven(new BuilderItem("b"), "BuilderItem2")
                .AndGiven(new BuilderItem("c"))
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>()))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBeA<string>();

    [Fact]
    public void BuildItems_Example6() =>
        GivenA<Builder>
                .AndGiven(new BuilderItem("a"), "BuilderItem1")
                .AndGiven(new BuilderItem("b"))
                .AndGiven(new BuilderItem("c"), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>()))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBeA<string>();

    [Fact]
    public void BuildItems_Example7() =>
        GivenA<Builder>
                .AndGiven("a", "string1")
                .AndGiven("b", "string2")
                .AndGiven("c", "string3")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string1")), "BuilderItem1")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string2")), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string3")), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void BuildItems_Example8() =>
        GivenA<Builder>
                .AndGiven("a", "string1")
                .AndGiven("b", "string2")
                .AndGiven("c", "string3")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string1")))
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string2")), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string3")), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>()))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void BuildItems_Example9() =>
        GivenA<Builder>
                .AndGiven("a", "string1")
                .AndGiven("b", "string2")
                .AndGiven("c", "string3")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string1")), "BuilderItem1")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string2")), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string3")))
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>()))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");


    [Fact]
    public void BuildItems_Example10() =>
        GivenA<Builder>
                .AndGiven("a")
                .AndGiven("b", "string2")
                .AndGiven("c", "string3")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>()), "BuilderItem1")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string2")), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string3")), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");


    [Fact]
    public void BuildItems_Example11() =>
        GivenA<Builder>
                .AndGiven("a", "string1")
                .AndGiven("b", "string2")
                .AndGiven("c")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string1")), "BuilderItem1")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string2")), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>()), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void BuildItems_Example12() =>
        GivenA<Builder>
                .AndGiven("a", "string1")
                .AndGiven("b")
                .AndGiven("c", "string3")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string1")), "BuilderItem1")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>()), "BuilderItem2")
                .AndGiven(arrangement => new BuilderItem(arrangement.GetThe<string>("string3")), "BuilderItem3")
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem1")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem2")))
                .ThenWhenIt(arrangement => arrangement.Sut.Add(arrangement.GetThe<BuilderItem>("BuilderItem3")))
                .ThenWhenIt(sut => sut.Build())
            .ThenTheResultShouldBe("abc");

    [Fact]
    public void AddItemAndReturn_Example1() =>
        GivenA<Builder>
            .AndGivenA<IBuilderItem>()
            .WhenIt(arrangement => arrangement.Sut.AddAndReturn(arrangement.GetTheMockObject<IBuilderItem>()))
            .ThenTheResultShouldBe(arrangement => arrangement.Sut);

    [Fact]
    public void AddItemAndReturn_Example2() =>
        GivenA<Builder>
            .AndGivenA<IBuilderItem>()
            .WhenIt<IBuilder>(arrangement => sut => sut.AddAndReturn(arrangement.GetTheMockObject<IBuilderItem>()))
            .ThenTheResultShouldBe(arrangement => arrangement.Sut);

    [Fact]
    public void AddItem() =>
        GivenA<Builder>
            .AndGivenA<IBuilderItem>()
            .WhenIt(arrangement => arrangement.Sut.Add(arrangement.GetTheMockObject<IBuilderItem>()));
}
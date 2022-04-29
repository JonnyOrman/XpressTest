using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class MultiConstructorClassTests
{
    [Fact]
    public void Constructor1() =>
        GivenA<MultiConstructorClass>
            .WhenItIsConstructed()
            .ThenIts(result => result.Name).ShouldBeNull()
            .ThenIts(result => result.Value).ShouldBe(0);

    [Fact]
    public void Constructor2() =>
        GivenA<MultiConstructorClass>
            .With("Custom Name")
            .WhenItIsConstructed()
            .ThenIts(result => result.Name).ShouldBe("Custom Name")
            .ThenIts(result => result.Value).ShouldBe(0);

    [Fact]
    public void Constructor3() =>
        GivenA<MultiConstructorClass>
            .With("Custom Name")
            .With(123)
            .WhenItIsConstructed()
            .ThenIts(result => result.Name).ShouldBe("Custom Name")
            .ThenIts(result => result.Value).ShouldBe(123);
}
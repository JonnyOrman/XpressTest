using FluentAssertions;
using Xunit;

namespace XpressTest;

public static class AssertionExtensions
{
    public static void ThenTheResultShouldBe<T>(this T actualResult, T expectedResult)
    {
        Assert.Equal(expectedResult, actualResult);
    }

    public static void ThenTheResultShouldBeEquivalentTo<T>(this T actualResult, T expectedResult)
    {
        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    public static void ThenTheResultShouldBeA<TExpectedResult>(this object actualResult)
    {
        Assert.IsType<TExpectedResult>(actualResult);
    }
}

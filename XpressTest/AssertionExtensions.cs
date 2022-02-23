using FluentAssertions;

namespace XpressTest;

public static class AssertionExtensions
{
    public static void ThenTheResultShouldBe<T>(this T actualResult, T expectedResult)
    {
        expectedResult.Should().Be(actualResult);
    }

    public static void ThenTheResultShouldBeEquivalentTo<T>(this T actualResult, T expectedResult)
    {
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}

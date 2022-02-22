using Xunit;

namespace XpressTest;

public static class AssertionExtensions
{
    public static void ThenTheResultShouldBe<T>(this T actualResult, T expectedResult)
    {
        Assert.Equal(expectedResult, actualResult);
    }
}

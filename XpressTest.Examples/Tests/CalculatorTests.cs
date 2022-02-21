using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class CalculatorTests
{
    [Fact]
    public void AddNumbers() =>
        GivenA<Calculator>
            .WhenIt(sut => sut.Add(2, 2))
            .ThenTheResultShouldBe(4);
}
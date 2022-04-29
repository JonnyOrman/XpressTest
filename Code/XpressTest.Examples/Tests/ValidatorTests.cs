using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ValidatorTests
{
    [Theory]
    [InlineData("ValidName", true)]
    [InlineData(" ", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ValidateParameters(string name, bool expectedResult) =>
        GivenA<Validator>
            .AndGiven(new EntityParameters(name))
            .WhenIt(arrangement => arrangement.Sut.IsValid(arrangement.GetThe<EntityParameters>()))
            .ThenTheResultShouldBe(expectedResult);
}
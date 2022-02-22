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
            .AndGiven(new EntityParameters(name), "EntityParameters")
            .WhenIt(action => action.Sut.IsValid(action.GetObject<EntityParameters>("EntityParameters")))
            .ThenItShould(assertion => { Assert.Equal(expectedResult, assertion.Result); })
            .Test();
}
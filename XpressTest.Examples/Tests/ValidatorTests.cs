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
            .And(new EntityParameters(name), "EntityParameters")
            .WhenIt(action => action.Sut.IsValid(action.Objects.Get<EntityParameters>("EntityParameters")))
            .ThenItShould(assertion => { Assert.Equal(expectedResult, assertion.Result); })
            .Test();
}
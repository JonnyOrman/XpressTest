using FluentAssertions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAssertionExtensions
{
    [Fact]
    public void WhenAResultIsTheExpectedResultThenItShouldNotThrow()
    {
        var actualResult = new object();

        var expectedResult = actualResult;
        
        var exception = Record.Exception(() => actualResult.ThenTheResultShouldBe(expectedResult));

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenAResultIsNotTheExpectedResultThenItShouldThrowEqualException()
    {
        var actualResult = new object();

        var expectedResult = new object();
        
        Assert.Throws<EqualException>(() => actualResult.ThenTheResultShouldBe(expectedResult));
    }
    
    [Fact]
    public void WhenAResultIsTheEquivalentResultThenItShouldNotThrow()
    {
        var actualResult = new TestResult(1);

        var expectedResult = new TestResult(1);
        
        var exception = Record.Exception(() => actualResult.ThenTheResultShouldBeEquivalentTo(expectedResult));

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenAResultIsNotTheEquivalentResultThenItShouldThrowXunitException()
    {
        var actualResult = new TestResult(1);

        var expectedResult = new TestResult(2);
        
        Assert.Throws<XunitException>(() => actualResult.ThenTheResultShouldBeEquivalentTo(expectedResult));
    }
    
    [Fact]
    public void WhenAResultIsTheExpectedTypeThenItShouldNotThrow()
    {
        var actualResult = new TestDerivedResult();

        var exception = Record.Exception(() => actualResult.ThenTheResultShouldBeA<TestDerivedResult>());

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenAResultIsNotTheExpectedTypeThenItShouldThrowIsTypeException()
    {
        var actualResult = new object();

        Assert.Throws<IsTypeException>(() => actualResult.ThenTheResultShouldBeA<TestDerivedResult>());
    }
}
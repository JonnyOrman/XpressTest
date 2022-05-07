using FluentAssertions;
using System;
using System.Linq.Expressions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultProvider
{
    [Fact]
    public void WhenItGetsTheResultThenItReturnsTheResultFromTheSutFunc()
    {
        var testSut = new TestResult(123);
        
        Expression<Func<TestResult, int>> testResultExpression = testResult => testResult.Value;
        
        var sut = new ResultProvider<TestResult, int>(
            testSut,
            testResultExpression
        );
        
        var result = sut.Get();
        
        result.Should().Be(123);
    }
}
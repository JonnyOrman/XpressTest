using System;
using FluentAssertions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultProvider
{
    [Fact]
    public void WhenItGetsTheResultThenItReturnsTheResultFromTheSutFunc()
    {
        var testSut = new TestResult(123);

        Func<TestResult, int> testResultFunc = testResult => testResult.Value;

        var sut = new ResultProvider<TestResult, int>(
            testSut,
            testResultFunc
        );

        var result = sut.Get();

        result.Should().Be(123);
    }
}
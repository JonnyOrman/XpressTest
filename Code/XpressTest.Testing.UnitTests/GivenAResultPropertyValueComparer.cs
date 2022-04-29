using FluentAssertions;
using System;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyValueComparer
{
    [Fact]
    public void WhenItComparesAResultPropertyValueToAMatchingExpectedValueThenItDoesNotThrow()
    {
        var testResult = new TestResult(123);

        Func<TestResult, int> targetFunc = testResult => testResult.Value;

        var sut = new ResultPropertyValueComparer<TestResult, int>(
            testResult,
            targetFunc
            );

        var result = Record.Exception(() => sut.Compare(123));

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItComparesAResultPropertyValueToANonMatchingExpectedValueThenItThrows()
    {
        var testResult = new TestResult(123);

        Func<TestResult, int> targetFunc = testResult => testResult.Value;

        var sut = new ResultPropertyValueComparer<TestResult, int>(
            testResult,
            targetFunc
        );

        var result = Record.Exception(() => sut.Compare(124));

        result.Should().BeOfType<EqualException>();
    }
}
using FluentAssertions;
using NSubstitute;
using System;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyTargeter
{
    [Fact]
    public void WhenItTargetsAResultPropertyThenItReturnsAResultPropertyAsserter()
    {
        Func<object, object> targetFunc = obj => new object();

        var testResult = new object();

        var arrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            arrangement
            );

        var result = sut.ThenTheResult(targetFunc);

        result.Should().BeOfType<ResultPropertyAsserter<object, object, object>>();
    }

    [Fact]
    public void WhenItAssertsTheResultIsTheExpectedResultThenItDoesNotThrow()
    {
        var expectedResult = new object();

        var testResult = expectedResult;

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsTheResultIsNotTheExpectedResultThenItThrows()
    {
        var expectedResult = new object();

        var testResult = new object();

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        result.Should().BeOfType<EqualException>();
    }

    [Fact]
    public void WhenItAssertsTheResultIsTheExpectedResultFromTheArrangementThenItDoesNotThrow()
    {
        var expectedResult = new object();

        var testResult = expectedResult;

        Func<ISutArrangement<object>, object> func = sutArrangement => expectedResult;

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(func));

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsTheResultIsNotTheExpectedResultFromTheArrangementThenItThrows()
    {
        var expectedResult = new object();

        var testResult = new object();

        Func<ISutArrangement<object>, object> func = sutArrangement => expectedResult;

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(func));

        result.Should().BeOfType<EqualException>();
    }

    [Fact]
    public void WhenItAssertsTheResultIsTheExpectedTypeThenItDoesNotThrow()
    {
        var testResult = new object();

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBeA<object>());

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsTheResultIsNotTheExpectedTypeThenItThrows()
    {
        var testResult = new object();

        var sut = new ResultPropertyTargeter<object, object>(
            testResult,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBeA<TestObject>());

        result.Should().BeOfType<IsTypeException>();
    }
}
using FluentAssertions;
using NSubstitute;
using System;
using XpressTest.Narration;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenASimpleResultAsserter
{
    [Fact]
    public void WhenItAssertsAnExpectedActionThenItDoesNotThrow()
    {
        var expectedResult = new object();

        Action<IResultAssertion<object>> action = resultAssertion =>
            Assert.Equal(expectedResult, resultAssertion.Result);

        var testSut = new object();

        var arrangement = Substitute.For<IArrangement>();

        Func<object> resultFunc = () => expectedResult;

        var sut = new SimpleResultAsserter<object, object>(
            testSut,
            arrangement,
            resultFunc,
            null,
            null
            );

        var result = Record.Exception(() => sut.Then(action));

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsAnUnexpectedActionThenItThrows()
    {
        var expectedResult = new object();

        Action<IResultAssertion<object>> action = resultAssertion =>
            Assert.Equal(expectedResult, resultAssertion.Result);

        var testSut = new object();

        var arrangement = Substitute.For<IArrangement>();

        Func<object> resultFunc = () => new object();

        var sut = new SimpleResultAsserter<object, object>(
            testSut,
            arrangement,
            resultFunc,
            null,
            null
        );

        var result = Record.Exception(() => sut.Then(action));

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItAssertsAnExpectedResultThenItDoesNotThrow()
    {
        var expectedResult = new object();

        Func<object> resultFunc = () => expectedResult;

        var resultNarrator = Substitute.For<IResultNarrator<object>>();

        var sut = new SimpleResultAsserter<object, object>(
            null,
            null,
            resultFunc,
            null,
            resultNarrator
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        resultNarrator.Received(1).NarrateExpectedResult(expectedResult);
        resultNarrator.Received(1).NarrateValidResult();
        resultNarrator.Received(1).NarratePassedTest();
        resultNarrator.Received(0).NarrateInvalidResult(Arg.Any<object>());
        resultNarrator.Received(0).NarrateFailedTest();
        
        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsAnUnexpectedResultThenItThrows()
    {
        var expectedResult = new object();

        var actualResult = new object();

        Func<object> resultFunc = () => actualResult;

        var resultNarrator = Substitute.For<IResultNarrator<object>>();

        var sut = new SimpleResultAsserter<object, object>(
            null,
            null,
            resultFunc,
            null,
            resultNarrator
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        resultNarrator.Received(1).NarrateExpectedResult(expectedResult);
        resultNarrator.Received(0).NarrateValidResult();
        resultNarrator.Received(0).NarratePassedTest();
        resultNarrator.Received(1).NarrateInvalidResult(actualResult);
        resultNarrator.Received(1).NarrateFailedTest();

        result.Should().BeOfType<EqualException>();
    }

    [Fact]
    public void WhenItAssertsAnExceptionIsThrownThenItAsssertsTheException()
    {
        var exceptionAsserter = Substitute.For<IExceptionAsserter>();

        var sut = new SimpleResultAsserter<object, object>(
            null,
            null,
            null,
            exceptionAsserter,
            null
        );

        sut.ThenItShouldThrow<Exception>();

        exceptionAsserter.Received(1).ThenItShouldThrow<Exception>();
    }
}
using FluentAssertions;
using NSubstitute;
using System;
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

        var sut = new SimpleResultAsserter<object, object>(
            null,
            null,
            resultFunc,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        result.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsAnUnexpectedResultThenItThrows()
    {
        var expectedResult = new object();

        Func<object> resultFunc = () => new object();

        var sut = new SimpleResultAsserter<object, object>(
            null,
            null,
            resultFunc,
            null
        );

        var result = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

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
            exceptionAsserter
        );

        sut.ThenItShouldThrow<Exception>();

        exceptionAsserter.Received(1).ThenItShouldThrow<Exception>();
    }
}
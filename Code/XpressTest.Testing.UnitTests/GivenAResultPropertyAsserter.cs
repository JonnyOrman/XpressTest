using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyAsserter
{
    [Fact]
    public void WhenItAssertsThatAPropertyValueIsTheExpectedValueThenItAssertsTheValue()
    {
        var expectedValue = new object();

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var resultPropertyValueAsserter = Substitute.For<IResultPropertyValueAsserter<object, object, object>>();
        resultPropertyValueAsserter.Assert(expectedValue).Returns(resultPropertyTargeter);

        var sut = new ResultPropertyAsserter<object, object, object>(
            resultPropertyValueAsserter,
            null,
            null
            );

        var result = sut.ShouldBe(expectedValue);

        result.Should().Be(resultPropertyTargeter);
    }

    [Fact]
    public void WhenItAssertsThatAPropertyValueIsNotTheExpectedValueThenItThrows()
    {
        var expectedValue = new object();

        var exception = new Exception();

        var resultPropertyValueAsserter = Substitute.For<IResultPropertyValueAsserter<object, object, object>>();
        resultPropertyValueAsserter
            .When(x => x.Assert(expectedValue))
            .Do(x => throw exception);

        var sut = new ResultPropertyAsserter<object, object, object>(
            resultPropertyValueAsserter,
            null,
            null
        );

        var result = Record.Exception(() => sut.ShouldBe(expectedValue));

        result.Should().Be(exception);
    }

    [Fact]
    public void WhenItAssertsThatAPropertyValueIsTheExpectedValueFromTheArrangementThenItAssertsTheValue()
    {
        var expectedValue = new object();

        Func<IReadArrangement, object> func = readArrangement => expectedValue;

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var resultPropertyValueAsserter = Substitute.For<IResultPropertyValueAsserter<object, object, object>>();
        resultPropertyValueAsserter.Assert(expectedValue).Returns(resultPropertyTargeter);

        var sut = new ResultPropertyAsserter<object, object, object>(
            resultPropertyValueAsserter,
            null,
            null
        );

        var result = sut.ShouldBe(expectedValue);

        result.Should().Be(resultPropertyTargeter);
    }

    [Fact]
    public void WhenItAssertsThatAPropertyValueIsNotTheExpectedValueFromTheArrangementThenItAssertsTheValue()
    {
        var expectedValue = new object();

        Func<IReadArrangement, object> func = readArrangement => expectedValue;

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var exception = new Exception();

        var resultPropertyValueAsserter = Substitute.For<IResultPropertyValueAsserter<object, object, object>>();
        resultPropertyValueAsserter
            .When(x => x.Assert(expectedValue))
            .Do(x => throw exception);

        var sut = new ResultPropertyAsserter<object, object, object>(
            resultPropertyValueAsserter,
            null,
            null
        );

        var result = Record.Exception(() => sut.ShouldBe(expectedValue));

        result.Should().Be(exception);
    }

    [Fact]
    public void WhenItAssertsThatAPropertyValueIsNullThenItAssertsTheValue()
    {
        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var resultPropertyNullAsserter = Substitute.For<IResultPropertyNullAsserter<object, object>>();
        resultPropertyNullAsserter.Assert().Returns(resultPropertyTargeter);

        var sut = new ResultPropertyAsserter<object, object, object>(
            null,
            resultPropertyNullAsserter,
            null
        );

        var result = sut.ShouldBeNull();

        result.Should().Be(resultPropertyTargeter);
    }

    [Fact]
    public void WhenItAssertsThatAPropertyValueIsNotNullThenItAssertsTheValue()
    {
        var exception = new Exception();

        var resultPropertyNullAsserter = Substitute.For<IResultPropertyNullAsserter<object, object>>();
        resultPropertyNullAsserter
            .When(x => x.Assert())
            .Do(x => throw exception);

        var sut = new ResultPropertyAsserter<object, object, object>(
            null,
            resultPropertyNullAsserter,
            null
        );

        var result = Record.Exception(() => sut.ShouldBeNull());

        result.Should().Be(exception);
    }
}
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyValueAsserter
{
    [Fact]
    public void WhenItAssertsAResultPropertyValueThatMatchesThenItReturnsTheResultPropertyTargeter()
    {
        var expectedValue = new object();

        var resultPropertyValueComparer = Substitute.For<IResultPropertyValueComparer<object>>();

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var sut = new ResultPropertyValueAsserter<object, object, object>(
            resultPropertyValueComparer,
            resultPropertyTargeter
            );

        var result = sut.Assert(expectedValue);

        resultPropertyValueComparer.Received(1).Compare(expectedValue);

        result.Should().Be(resultPropertyTargeter);
    }

    [Fact]
    public void WhenItAssertsAResultPropertyValueThatDoesNotMatchThenItThrows()
    {
        var expectedValue = new object();

        var exception = new Exception();

        var resultPropertyValueComparer = Substitute.For<IResultPropertyValueComparer<object>>();
        resultPropertyValueComparer
            .When(x => x.Compare(expectedValue))
            .Do(x => throw exception);

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();

        var sut = new ResultPropertyValueAsserter<object, object, object>(
            resultPropertyValueComparer,
            resultPropertyTargeter
        );

        var result = Record.Exception(() => sut.Assert(expectedValue));

        result.Should().Be(exception);
    }
}
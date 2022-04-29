using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockCountVerifierWithAMockResultExpressionThenItCreatesAResultMockCountVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var resultMockCounterVerifier = Substitute.For<IMockCountVerifier<object>>();

        var resultMockCountVerifierCreator = Substitute.For<IResultMockCountVerifierCreator<object, object>>();
        resultMockCountVerifierCreator.Create(expression).Returns(resultMockCounterVerifier);

        var sut = new MockCountVerifierCreator<object, object>(
            resultMockCountVerifierCreator,
            null,
            null,
            null
            );

        var result = sut.Create(expression);

        result.Should().Be(resultMockCounterVerifier);
    }

    [Fact]
    public void WhenItCreatesAMockCountVerifierWithAnArrangementMockResultExpressionThenItCreatesAnArrangementResultMockCountVerifier()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> expression = arrangement => obj => new object();

        var asserter = new object();

        var arrangementResultMockCounterVerifier = Substitute.For<IMockCountVerifier<object>>();

        var arrangementResultMockCountVerifierCreator = Substitute.For<IArrangementResultMockCountVerifierCreator<object, object>>();
        arrangementResultMockCountVerifierCreator.Create(expression, asserter).Returns(arrangementResultMockCounterVerifier);

        var sut = new MockCountVerifierCreator<object, object>(
            null,
            arrangementResultMockCountVerifierCreator,
            null,
            null
        );

        var result = sut.Create(
            expression,
            asserter
            );

        result.Should().Be(arrangementResultMockCounterVerifier);
    }

    [Fact]
    public void WhenItCreatesAMockCountVerifierWithAMockActionExpressionThenItCreatesAVoidMockCountVerifier()
    {
        Expression<Action<object>> expression = obj => new object();

        var voidMockCounterVerifier = Substitute.For<IMockCountVerifier<object>>();

        var voidMockCounterVerifierCreator = Substitute.For<IVoidMockCountVerifierCreator<object, object>>();
        voidMockCounterVerifierCreator.Create(expression).Returns(voidMockCounterVerifier);

        var sut = new MockCountVerifierCreator<object, object>(
            null,
            null,
            voidMockCounterVerifierCreator,
            null
        );

        var result = sut.Create(
            expression
        );

        result.Should().Be(voidMockCounterVerifier);
    }

    [Fact]
    public void WhenItCreatesAMockCountVerifierWithAnArrangementMockActionFuncThenItCreatesAnArrangementVoidMockCountVerifier()
    {
        Func<IReadArrangement, Expression<Action<object>>> func = arrangement => obj => new object();

        var asserter = new object();

        var arrangementVoidMockCountVerifier = Substitute.For<IMockCountVerifier<object>>();

        var arrangementVoidMockCountVerifierCreator = Substitute.For<IArrangementVoidMockCountVerifierCreator<object, object>>();
        arrangementVoidMockCountVerifierCreator.Create(func, asserter).Returns(arrangementVoidMockCountVerifier);

        var sut = new MockCountVerifierCreator<object, object>(
            null,
            null,
            null,
            arrangementVoidMockCountVerifierCreator
        );

        var result = sut.Create(
            func,
            asserter
        );

        result.Should().Be(arrangementVoidMockCountVerifier);
    }
}
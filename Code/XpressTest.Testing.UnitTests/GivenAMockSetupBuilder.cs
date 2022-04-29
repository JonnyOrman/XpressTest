using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockSetupBuilder
{
    [Fact]
    public void WhenItSetsUpWithAnArrangementExpressionThenItStartsAMockSetupResultBuilder()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = arrangement => obj => new object();

        var obj = new object();

        var chainer = Substitute.For<IMockBuilderChainer<object, object, object>>();

        var mockResultBuilder = Substitute.For<IMockResultBuilder<object, IMockSetupBuilder<object, object>>>();

        var sut = new MockSetupBuilder<object, object, object>(
            obj,
            null,
            chainer
            );

        chainer.StartMockSetupResultBuilder(
            func,
            obj,
            sut
        ).Returns(mockResultBuilder);

        var result = sut.ThatDoes(func);

        result.Should().Be(mockResultBuilder);
    }

    [Fact]
    public void WhenItSetsUpWithAnExpressionThenItStartsAMockSetupResultBuilder()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var obj = new object();

        var chainer = Substitute.For<IMockBuilderChainer<object, object, object>>();

        var mockResultBuilder = Substitute.For<IMockResultBuilder<object, IMockSetupBuilder<object, object>>>();

        var sut = new MockSetupBuilder<object, object, object>(
            obj,
            null,
            chainer
            );

        chainer.StartMockSetupResultBuilder(
            expression,
            obj,
            sut
        ).Returns(mockResultBuilder);

        var result = sut.ThatDoes(expression);

        result.Should().Be(mockResultBuilder);
    }
}
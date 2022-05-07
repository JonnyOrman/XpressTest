using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using XpressTest.Narration;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockSetupBuilder
{
    [Fact]
    public void WhenItSetsUpWithAnArrangementExpressionThenItStartsAMockSetupResultBuilder()
    {
        Expression<Func<ITestObject, object>> expression = obj => obj.ReturnObject();
        
        Func<IReadArrangement, Expression<Func<ITestObject, object>>> func = arrangement => expression;

        var obj = Substitute.For<ITestObject>();

        var chainer = Substitute.For<IMockBuilderChainer<object, ITestObject, ITestObject>>();

        var mockResultBuilder = Substitute.For<IMockResultBuilder<object, IMockSetupBuilder<object, ITestObject>>>();

        var functionNarrator = Substitute.For<IFunctionNarrator<ITestObject>>();

        var sut = new MockSetupBuilder<object, ITestObject, ITestObject>(
            obj,
            null,
            chainer,
            functionNarrator
            );

        chainer.StartMockSetupResultBuilder(
            func,
            obj,
            sut
        ).Returns(mockResultBuilder);

        var result = sut.ThatDoes(func);
        
        functionNarrator.Received(1).Narrate(expression);

        result.Should().Be(mockResultBuilder);
    }

    [Fact]
    public void WhenItSetsUpWithAnExpressionThenItStartsAMockSetupResultBuilder()
    {
        Expression<Func<ITestObject, object>> expression = obj => obj.ReturnObject();

        var obj = Substitute.For<ITestObject>();

        var chainer = Substitute.For<IMockBuilderChainer<object, ITestObject, ITestObject>>();

        var mockResultBuilder = Substitute.For<IMockResultBuilder<object, IMockSetupBuilder<object, ITestObject>>>();

        var functionNarrator = Substitute.For<IFunctionNarrator<ITestObject>>();

        var sut = new MockSetupBuilder<object, ITestObject, ITestObject>(
            obj,
            null,
            chainer,
            functionNarrator
            );

        chainer.StartMockSetupResultBuilder(
            expression,
            obj,
            sut
        ).Returns(mockResultBuilder);

        var result = sut.ThatDoes(expression);
        
        functionNarrator.Received(1).Narrate(expression);

        result.Should().Be(mockResultBuilder);
    }
}
using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultMockVerifier
{
    [Fact]
    public void WhenItVerifiesAnArrangementFuncThenItCreatesAMockCountVerifier()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = readArrangement => obj => new object();

        var mockCountVerifier = Substitute.For<IMockCountVerifier<IResultAsserter<object, object>>>();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IResultAsserter<object, object>>>();
        mockCountVerifierCreator.Create(func, resultAsserter).Returns(mockCountVerifier);

        var sut = new ResultMockVerifier<object, object, object>(
            mockCountVerifierCreator,
            resultAsserter
            );

        var result = sut.Should(func);

        result.Should().Be(mockCountVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAFuncExpressionThenItCreatesAMockCountVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var mockCountVerifier = Substitute.For<IMockCountVerifier<IResultAsserter<object, object>>>();

        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IResultAsserter<object, object>>>();
        mockCountVerifierCreator.Create(expression).Returns(mockCountVerifier);

        var sut = new ResultMockVerifier<object, object, object>(
            mockCountVerifierCreator,
            null
        );

        var result = sut.Should(expression);

        result.Should().Be(mockCountVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAnArrangementActionThenItCreatesAMockCountVerifier()
    {
        Func<IReadArrangement, Expression<Action<object>>> func = readArrangement => obj => new object();

        var mockCountVerifier = Substitute.For<IMockCountVerifier<IResultAsserter<object, object>>>();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IResultAsserter<object, object>>>();
        mockCountVerifierCreator.Create(func, resultAsserter).Returns(mockCountVerifier);

        var sut = new ResultMockVerifier<object, object, object>(
            mockCountVerifierCreator,
            resultAsserter
        );

        var result = sut.Should(func);

        result.Should().Be(mockCountVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAnActionExpressionThenItCreatesAMockCountVerifier()
    {
        Expression<Action<object>> expression = obj => new object();

        var mockCountVerifier = Substitute.For<IMockCountVerifier<IResultAsserter<object, object>>>();

        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IResultAsserter<object, object>>>();
        mockCountVerifierCreator.Create(expression).Returns(mockCountVerifier);

        var sut = new ResultMockVerifier<object, object, object>(
            mockCountVerifierCreator,
            null
        );

        var result = sut.Should(expression);

        result.Should().Be(mockCountVerifier);
    }
}
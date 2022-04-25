using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnAsyncResultMockVerifier
{
    [Fact]
    public void WhenItCreatesAMockCountVerifierFromAMockActionThenItCreatesTheMockCounterVerifierCreator()
    {
        Func<IReadArrangement, Expression<Action<object>>> func = readArrangement => obj => new object();

        var asserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var mockCounterVerifier = Substitute.For<IMockCountVerifier<IAsyncResultAsserter<object, object>>>();
        
        var mockCounterVerifierCreator =
            Substitute.For<IMockCountVerifierCreator<object, IAsyncResultAsserter<object, object>>>();
        mockCounterVerifierCreator.Create(
            func,
            asserter
        ).Returns(mockCounterVerifier);

        var sut = new AsyncResultMockVerifier<object, object, object>(
            mockCounterVerifierCreator,
            asserter
            );

        var result = sut.Should(func);

        result.Should().Be(mockCounterVerifier);
    }
    
    [Fact]
    public void WhenItCreatesAMockCountVerifierFromAMockFuncThenItCreatesTheMockCounterVerifierCreator()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = readArrangement => obj => new object();

        var asserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var mockCounterVerifier = Substitute.For<IMockCountVerifier<IAsyncResultAsserter<object, object>>>();
        
        var mockCounterVerifierCreator =
            Substitute.For<IMockCountVerifierCreator<object, IAsyncResultAsserter<object, object>>>();
        mockCounterVerifierCreator.Create(
            func,
            asserter
        ).Returns(mockCounterVerifier);

        var sut = new AsyncResultMockVerifier<object, object, object>(
            mockCounterVerifierCreator,
            asserter
        );

        var result = sut.Should(func);

        result.Should().Be(mockCounterVerifier);
    }
    
    [Fact]
    public void WhenItCreatesAMockCountVerifierFromAMockExpressionThenItCreatesTheMockCounterVerifierCreator()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var asserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var mockCounterVerifier = Substitute.For<IMockCountVerifier<IAsyncResultAsserter<object, object>>>();
        
        var mockCounterVerifierCreator =
            Substitute.For<IMockCountVerifierCreator<object, IAsyncResultAsserter<object, object>>>();
        mockCounterVerifierCreator.Create(
            expression
        ).Returns(mockCounterVerifier);

        var sut = new AsyncResultMockVerifier<object, object, object>(
            mockCounterVerifierCreator,
            asserter
        );

        var result = sut.Should(expression);

        result.Should().Be(mockCounterVerifier);
    }
}
using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidMockVerifier
{
    [Fact]
    public void WhenItVerifiesAMockFuncThenItCreatesAMockCountVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();
        
        var mockCountVerifier = Substitute.For<IMockCountVerifier<IVoidAsserter<object>>>();
        
        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IVoidAsserter<object>>>();
        mockCountVerifierCreator.Create(expression).Returns(mockCountVerifier);
        
        var sut = new VoidMockVerifier<object, object>(
            mockCountVerifierCreator,
            null
            );

        var result = sut.Should(expression);

        result.Should().Be(mockCountVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAnArrangementMockActionThenItCreatesAMockCountVerifier()
    {
        Func<IReadArrangement, Expression<Action<object>>> func = arrangement => obj => new object();
        
        var mockCountVerifier = Substitute.For<IMockCountVerifier<IVoidAsserter<object>>>();

        var asserter = Substitute.For<IVoidAsserter<object>>();
        
        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IVoidAsserter<object>>>();
        mockCountVerifierCreator.Create(func, asserter).Returns(mockCountVerifier);
        
        var sut = new VoidMockVerifier<object, object>(
            mockCountVerifierCreator,
            asserter
        );

        var result = sut.Should(func);

        result.Should().Be(mockCountVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAMockActionThenItCreatesAMockCountVerifier()
    {
        Expression<Action<object>> expression = obj => new object();
        
        var mockCountVerifier = Substitute.For<IMockCountVerifier<IVoidAsserter<object>>>();

        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IVoidAsserter<object>>>();
        mockCountVerifierCreator.Create(expression).Returns(mockCountVerifier);
        
        var sut = new VoidMockVerifier<object, object>(
            mockCountVerifierCreator,
            null
        );

        var result = sut.Should(expression);

        result.Should().Be(mockCountVerifier);
    }
}
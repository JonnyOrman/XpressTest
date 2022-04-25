using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockVariableBuilderChainer
{
    [Fact]
    public void WhenItStartsAMockSetupResultBuilderWithAnArrangementExpressionThenItReturnsAMockResultBuilder()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = readArrangement => obj => new object();

        var mock = Substitute.For<IMock<object>>();

        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new MockVariableBuilderChainer<object, object, IMock<object>>(
            null,
            null,
            arrangement,
            null
            );

        var result = sut.StartMockSetupResultBuilder(
            func,
            mock,
            mockSetupBuilder
        );

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItStartsAMockSetupResultBuilderWithAnExpressionThenItReturnsAMockResultBuilder()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var mock = Substitute.For<IMock<object>>();

        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new MockVariableBuilderChainer<object, object, IMock<object>>(
            null,
            null,
            arrangement,
            null
        );

        var result = sut.StartMockSetupResultBuilder(
            expression,
            mock,
            mockSetupBuilder
        );

        result.Should().NotBeNull();
    }
}
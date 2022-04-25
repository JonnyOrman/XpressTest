using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockCallCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockCallCountVerifierForAResultFuncThenItReturnsAMockResultCallCountVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();
        
        var mock = Substitute.For<IMock<object>>();
        
        var sut = new MockCallCountVerifierCreator<object>(
            mock
            );

        var result = sut.Create(expression);

        result.Should().BeOfType<MockResultCallCountVerifier<object, object>>();
    }
    
    
    [Fact]
    public void WhenItCreatesAMockCallCountVerifierForAnActionThenItReturnsAMockVoidCallCountVerifier()
    {
        Expression<Action<object>> expression = obj => new object();
        
        var mock = Substitute.For<IMock<object>>();
        
        var sut = new MockCallCountVerifierCreator<object>(
            mock
        );

        var result = sut.Create(expression);

        result.Should().BeOfType<MockVoidCallCountVerifier<object>>();
    }
}
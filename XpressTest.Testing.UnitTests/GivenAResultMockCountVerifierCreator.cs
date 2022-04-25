using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultMockCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAResultMockCountVerifierThenItReturnsAMockCountVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();
        
        var resultMockCallVerifierCreator = Substitute.For<IResultMockCallVerifierCreator<object, object>>();
        
        var sut = new ResultMockCountVerifierCreator<object, object>(
            resultMockCallVerifierCreator
            );

        var result = sut.Create(expression);

        result.Should().BeOfType<MockCountVerifier<object>>();
    }
}
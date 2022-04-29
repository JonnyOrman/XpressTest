using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultMockCallVerifierCreator
{
    [Fact]
    public void WhenItCreatesAResultMockCallVerifierThenItReturnsAMockCallVerifier()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var mockCallCountVerifierCreator = Substitute.For<IMockCallCountVerifierCreator<object>>();

        var asserter = new object();

        var sut = new ResultMockCallVerifierCreator<object, object>(
            mockCallCountVerifierCreator,
            asserter
            );

        var result = sut.Create(expression);

        result.Should().BeOfType<MockCallVerifier<object>>();
    }
}
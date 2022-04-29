using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnArrangementVoidMockCallVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockCallVerifierThenTheCreatedMockCallVerifierVerifiesTheCallCountAndReturnsTheAsserter()
    {
        Expression<Action<object>> expression = obj => new object();

        Func<IReadArrangement, Expression<Action<object>>> func = readArrangement => expression;

        var asserter = new object();

        var mockCallCountVerifier = Substitute.For<IMockCallCountVerifier>();

        var mockCallCountVerifierCreator = Substitute.For<IMockCallCountVerifierCreator<object>>();
        mockCallCountVerifierCreator.Create(expression).Returns(mockCallCountVerifier);

        var readArrangement = Substitute.For<IReadArrangement>();

        var sut = new ArrangementVoidMockCallVerifierCreator<object, object>(
            mockCallCountVerifierCreator,
            readArrangement
        );

        var result = sut.Create(
            func,
            asserter
        );

        var asserterResult = result.Verify(123);

        mockCallCountVerifier.Received(1).Verify(123);

        asserterResult.Should().Be(asserter);
    }
}
using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnArrangementVoidMockCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockCountVerifierThenTheCreatedMockCountVerifierVerifiesOneCall() =>
        RunTest(mockCountVerifier => mockCountVerifier.Once(), 1);

    [Fact]
    public void WhenItCreatesAMockCountVerifierThenTheCreatedMockCountVerifierVerifiesNoCalls() =>
        RunTest(mockCountVerifier => mockCountVerifier.Never(), 0);

    private static void RunTest(Func<IMockCountVerifier<object>, object> mockCountVerifierFunc, int callCountToVerify)
    {
        Func<IReadArrangement, Expression<Action<object>>> func = readArrangement => obj => new object();

        var asserter = new object();

        var mockCallVerifier = Substitute.For<IMockCallVerifier<object>>();
        mockCallVerifier.Verify(callCountToVerify).Returns(asserter);

        var arrangementResultMockCallVerifierCreator =
            Substitute.For<IArrangementVoidMockCallVerifierCreator<object, object>>();
        arrangementResultMockCallVerifierCreator.Create(func, asserter)
            .Returns(mockCallVerifier);

        var sut = new ArrangementVoidMockCountVerifierCreator<object, object>(
            arrangementResultMockCallVerifierCreator
        );

        var result = sut.Create(
            func,
            asserter
        );

        var asserterResult = mockCountVerifierFunc.Invoke(result);

        mockCallVerifier.Received(1).Verify(callCountToVerify);

        asserterResult.Should().Be(asserter);
    }
}
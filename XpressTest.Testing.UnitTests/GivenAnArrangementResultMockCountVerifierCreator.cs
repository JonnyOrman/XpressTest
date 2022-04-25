using System;
using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnArrangementResultMockCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockCountVerifierThenTheCreatedMockCountVerifierVerifiesOneCall() =>
        RunTest(mockCountVerifier => mockCountVerifier.Once(), 1);
    
    [Fact]
    public void WhenItCreatesAMockCountVerifierThenTheCreatedMockCountVerifierVerifiesNoCalls() =>
        RunTest(mockCountVerifier => mockCountVerifier.Never(), 0);

    private static void RunTest(Func<IMockCountVerifier<object>, object> mockCountVerifierFunc, int callCountToVerify)
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = readArrangement => obj => new object();
        
        var asserter = new object();
        
        var mockCallVerifier = Substitute.For<IMockCallVerifier<object>>();
        mockCallVerifier.Verify(callCountToVerify).Returns(asserter);
        
        var arrangementResultMockCallVerifierCreator =
            Substitute.For<IArrangementResultMockCallVerifierCreator<object, object>>();
        arrangementResultMockCallVerifierCreator.Create(func, asserter)
            .Returns(mockCallVerifier);
        
        var sut = new ArrangementResultMockCountVerifierCreator<object, object>(
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
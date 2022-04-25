using System;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockCallVerifier
{
    [Fact]
    public void WhenTheActualCallCountIsTheSameAsTheExpectedCallCountThenItReturnsTheAsserter()
    {
        var mockCallCountVerifier = Substitute.For<IMockCallCountVerifier>();

        var asserter = new object();
        
        var sut = new MockCallVerifier<object>(
            mockCallCountVerifier,
            asserter
            );

        var result = sut.Verify(123);
        
        mockCallCountVerifier.Received(1).Verify(123);

        result.Should().Be(asserter);
    }
    
    [Fact]
    public void WhenTheActualCallCountIsNotTheSameAsTheExpectedCallCountThenItThrows()
    {
        var exception = new Exception();
        
        var mockCallCountVerifier = Substitute.For<IMockCallCountVerifier>();
        mockCallCountVerifier
            .When(mockCallCountVerifier => mockCallCountVerifier.Verify(123))
            .Do(x => { throw exception; });
        
        var asserter = new object();
        
        var sut = new MockCallVerifier<object>(
            mockCallCountVerifier,
            asserter
        );

        var thrownException = Record.Exception(() => sut.Verify(123));

        thrownException.Should().Be(exception);
    }
}
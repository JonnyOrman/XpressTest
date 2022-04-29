using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockCounterVerifier
{
    [Fact]
    public void WhenItVerifiesThatTheCallWasMadeOnceThenItVerifiesThatThereWasOneCall()
    {
        var asserter = new object();

        var mockCallVerifier = Substitute.For<IMockCallVerifier<object>>();
        mockCallVerifier.Verify(1).Returns(asserter);

        var sut = new MockCountVerifier<object>(
            mockCallVerifier
            );

        var result = sut.Once();

        result.Should().Be(asserter);
    }

    [Fact]
    public void WhenItVerifiesThatTheCallWasNeverMadeThenItVerifiesThatThereWereZeroCalls()
    {
        var asserter = new object();

        var mockCallVerifier = Substitute.For<IMockCallVerifier<object>>();
        mockCallVerifier.Verify(0).Returns(asserter);

        var sut = new MockCountVerifier<object>(
            mockCallVerifier
        );

        var result = sut.Never();

        result.Should().Be(asserter);
    }
}
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAnAsyncResultAsserter
{
    [Fact]
    public void WhenItAssertsThatTheActualResultIsTheExpectedResultThenItDoesNotThrow()
    {
        var actualResult = new object();

        var expectedResult = actualResult;

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
            );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBe(expectedResult));

        exception.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsThatTheActualResultIsNotTheExpectedResultThenItThrowsEqualException()
    {
        var actualResult = new object();

        var expectedResult = new object();

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
        );

        Assert.Throws<EqualException>(() => sut.ThenTheResultShouldBe(expectedResult));
    }

    [Fact]
    public void WhenItAssertsThatTheActualResultIsTheExpectedFuncResultThenItDoesNotThrow()
    {
        var actualResult = new object();

        var expectedResult = actualResult;

        Func<ISutArrangement<object>, object> func = sutArrangement => expectedResult;

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBe(func));

        exception.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsThatTheActualResultIsNotTheExpectedFuncResultThenItThrowsEqualException()
    {
        var actualResult = new object();

        var expectedResult = new object();

        Func<ISutArrangement<object>, object> func = sutArrangement => expectedResult;

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
        );

        Assert.Throws<EqualException>(() => sut.ThenTheResultShouldBe(func));
    }

    [Fact]
    public void WhenItAssertsThatANullResultIsNullThenItDoesNotThrow()
    {
        object actualResult = null;

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBeNull());

        exception.Should().BeNull();
    }

    [Fact]
    public void WhenItAssertsThatANonNullResultIsNullThenItThrowsNullException()
    {
        var actualResult = new object();

        var sut = new AsyncResultAsserter<object, object>(
            actualResult,
            null,
            null
        );

        Assert.Throws<NullException>(() => sut.ThenTheResultShouldBeNull());
    }

    [Fact]
    public void WhenItCreatesAnAsyncResultMockVerifierThenItReturnsAnAsyncResultMockVerifier()
    {
        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();

        var asyncResultMockVerifier = Substitute.For<IAsyncResultMockVerifier<object, object, object>>();

        var sut = new AsyncResultAsserter<object, object>(
            null,
            null,
            resultMockVerifierCreator
        );

        resultMockVerifierCreator.Create<object>(sut).Returns(asyncResultMockVerifier);

        var result = sut.ThenTheAsync<object>();

        result.Should().Be(asyncResultMockVerifier);
    }

    [Fact]
    public void WhenItVerifiesAndAssertionActionThenTheActionIsInvokedOnAnAssertion()
    {
        var actionInvoked = false;

        Action<IResultAssertion<object>> action = assertion => { actionInvoked = true; };

        var result = new object();

        var arrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new AsyncResultAsserter<object, object>(
            result,
            arrangement,
            null
        );

        sut.ThenAsync(
            action
        );

        actionInvoked.Should().BeTrue();
    }

    [Fact]
    public void WhenItCreatesAnAsyncResultMockVerifierThenItCreatesTheAsyncResultMockVerifierWithTheMock()
    {
        var mock = Substitute.For<IMock<object>>();

        var arrangement = Substitute.For<ISutArrangement<object>>();
        arrangement.GetTheMock<object>().Returns(mock);

        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();

        var asyncResultMockVerifier = Substitute.For<IAsyncResultMockVerifier<object, object, object>>();

        var sut = new AsyncResultAsserter<object, object>(
            null,
            arrangement,
            resultMockVerifierCreator
        );

        resultMockVerifierCreator.Create(mock, sut).Returns(asyncResultMockVerifier);

        var result = sut.ThenThe<object>();

        result.Should().Be(asyncResultMockVerifier);
    }

    [Fact]
    public void WhenItCreatesAnAsyncResultMockVerifierFromAMoqMockThenItCreatesTheAsyncResultMockVerifier()
    {
        var moqMock = new Moq.Mock<object>();

        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();

        var asyncResultMockVerifier = Substitute.For<IAsyncResultMockVerifier<object, object, object>>();

        var sut = new AsyncResultAsserter<object, object>(
            null,
            null,
            resultMockVerifierCreator
        );

        resultMockVerifierCreator.Create(Arg.Is<Mock<object>>(mock => mock.MoqMock == moqMock), sut).Returns(asyncResultMockVerifier);

        var result = sut.ThenAsync(moqMock);

        result.Should().Be(asyncResultMockVerifier);
    }
}
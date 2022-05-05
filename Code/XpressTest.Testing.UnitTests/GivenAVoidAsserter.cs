using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidAsserter
{
    [Fact]
    public void WhenItVerifiesAMockThenItCreatesAVoidMockVerifier()
    {
        var voidMockVerifier = Substitute.For<IVoidMockVerifier<object, object>>();

        var voidMockVerifierCreator = Substitute.For<IVoidMockVerifierCreator<object>>();

        var sut = new VoidAsserter<object>(
            null,
            voidMockVerifierCreator,
            null
        );

        voidMockVerifierCreator.Create<object>(sut).Returns(voidMockVerifier);

        var result = sut.ThenThe<object>();

        result.Should().Be(voidMockVerifier);
    }

    [Fact]
    public void WhenItVerifiesANamedMockThenItCreatesAVoidMockVerifier()
    {
        var mockName = "MockName";

        var mock = Substitute.For<IMock<object>>();

        var voidMockVerifier = Substitute.For<IVoidMockVerifier<object, object>>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.GetTheMock<object>(mockName).Returns(mock);

        var voidMockVerifierCreator = Substitute.For<IVoidMockVerifierCreator<object>>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            voidMockVerifierCreator,
            null
        );

        voidMockVerifierCreator.Create(mock, sut).Returns(voidMockVerifier);

        voidMockVerifierCreator.Create<object>(sut).Returns(voidMockVerifier);

        var result = sut.ThenThe<object>();

        result.Should().Be(voidMockVerifier);
    }

    [Fact]
    public void WhenItVerifiesAMoqMockThenItCreatesAVoidMockVerifier()
    {
        var moqMock = new Moq.Mock<object>();

        var voidMockVerifier = Substitute.For<IVoidMockVerifier<object, object>>();

        var voidMockVerifierCreator = Substitute.For<IVoidMockVerifierCreator<object>>();

        var sut = new VoidAsserter<object>(
            null,
            voidMockVerifierCreator,
            null
        );

        voidMockVerifierCreator.Create(Arg.Is<Mock<object>>(mock => mock.MoqMock == moqMock), sut).Returns(voidMockVerifier);

        voidMockVerifierCreator.Create<object>(sut).Returns(voidMockVerifier);

        var result = sut.ThenThe<object>();

        result.Should().Be(voidMockVerifier);
    }

    [Fact]
    public void WhenItVerifiesASutArrangementActionThenItInvokesTheAction()
    {
        var actionInvoked = false;

        Action<ISutArrangement<object>> action = sutArrangement => { actionInvoked = true; };

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            null,
            null
        );

        sut.Then(action);

        actionInvoked.Should().BeTrue();
    }

    [Fact]
    public void WhenItVerifiesAnotherSutActionThenItInvokesTheActionAndReturnsTheVoidAsserter()
    {
        var actionInvoked = false;

        Action<object> action = sutArrangement => { actionInvoked = true; };

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            null,
            null
        );

        var result = sut.ThenWhenIt(action);

        actionInvoked.Should().BeTrue();

        result.Should().Be(sut);
    }
    
    [Fact]
    public void WhenItVerifiesAnotherSutArrangementActionThenItInvokesTheActionAndReturnsTheVoidAsserter()
    {
        var actionInvoked = false;

        Action<ISutArrangement<object>> action = sutArrangement => { actionInvoked = true; };

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            null,
            null
        );

        var result = sut.ThenWhenIt(action);

        actionInvoked.Should().BeTrue();

        result.Should().Be(sut);
    }

    [Fact]
    public void WhenItVerifiesASutFuncThenItReturnsAResultAsserter()
    {
        Func<object, object> func = obj => new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var exceptionAsserter = Substitute.For<IExceptionAsserter>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            null,
            exceptionAsserter
        );

        var result = sut.ThenWhenIt(func);

        result.Should().BeOfType<ResultAsserter<object, object>>();
    }
    
    [Fact]
    public void WhenItVerifiesASutArrangementFuncThenItReturnsAResultAsserter()
    {
        Func<ISutArrangement<object>, object> func = obj => new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var exceptionAsserter = Substitute.For<IExceptionAsserter>();

        var sut = new VoidAsserter<object>(
            sutArrangement,
            null,
            exceptionAsserter
        );

        var result = sut.ThenWhenIt(func);

        result.Should().BeOfType<ResultAsserter<object, object>>();
    }

    [Fact]
    public void WhenItVerifiesAnExceptionIsThrownThenItVerifiesTheExceptionIsThrown()
    {
        var exceptionAsserter = Substitute.For<IExceptionAsserter>();

        var sut = new VoidAsserter<object>(
            null,
            null,
            exceptionAsserter
        );

        sut.ThenItShouldThrow<Exception>();

        exceptionAsserter.Received(1).ThenItShouldThrow<Exception>();
    }
}
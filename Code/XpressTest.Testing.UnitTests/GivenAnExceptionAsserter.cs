using FluentAssertions;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnExceptionAsserter
{
    [Fact]
    public void WhenTheActionThrowsTheExpectedExceptionTypeThenItDoesNotThrowAnException()
    {
        Action action = () => throw new Exception();

        var sut = new ExceptionAsserter(action);

        var result = Record.Exception(() => sut.ThenItShouldThrow<Exception>());

        result.Should().BeNull();
    }

    [Fact]
    public void WhenTheActionThrowsANonExpectedExceptionTypeThenItThrowsTheException()
    {
        var exception = new Exception();

        Action action = () => throw exception;

        var sut = new ExceptionAsserter(action);

        var result = Record.Exception(() => sut.ThenItShouldThrow<NullReferenceException>());

        result.Should().Be(exception);
    }

    [Fact]
    public void WhenTheActionDoesNotThrowAnExceptionThenItThrowsAnExceptionNotThrownException()
    {
        Action action = () => { };

        var sut = new ExceptionAsserter(action);

        var result = Record.Exception(() => sut.ThenItShouldThrow<Exception>());

        result.Should().BeOfType<ExceptionNotThrownException<Exception>>();
    }
}
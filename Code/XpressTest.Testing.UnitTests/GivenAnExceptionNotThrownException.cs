using FluentAssertions;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnExceptionNotThrownException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new ExceptionNotThrownException<Exception>();

        sut.Message.Should().Be("An Exception of type Exception was not thrown");
        sut.ExpectedExceptionType.Should().Be(typeof(Exception));
    }
}
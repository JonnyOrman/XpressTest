using FluentAssertions;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenVoidExceptionAsserterInitialiser
{
    [Fact]
    public void WhenItInitialisesAnActionExceptionAsserterThenItReturnsAnExceptionAsserter()
    {
        Action<object> action = obj => { };

        var result = VoidExceptionAsserterInitialiser<object>.Initialise(action);

        result.Should().BeOfType<ExceptionAsserter>();
    }
}
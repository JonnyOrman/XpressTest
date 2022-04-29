using FluentAssertions;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenSimpleVoidActionExecutorInitialiser
{
    [Fact]
    public void WhenItInitialisesASimpleVoidActionExecutorThenItReturnsASimpleVoidActionExecutor()
    {
        Action<object> action = obj => { };

        var result = SimpleVoidActionExecutorInitialiser<object>.Initialise(action);

        result.Should().BeOfType<SimpleVoidActionExecutor<object>>();
    }
}
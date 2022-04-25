using System;
using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASimpleVoidActionExecutor
{
    [Fact]
    public void WhenItExecutesTheActionThenTheActionIsExecuted()
    {
        var actionExecuted = false;
        
        var testSut = new object();

        Action<object> action = obj =>
        {
            actionExecuted = true;
        };
        
        var sut = new SimpleVoidActionExecutor<object>(
            testSut,
            action
            );
        
        sut.Execute();

        actionExecuted.Should().BeTrue();
    }
}
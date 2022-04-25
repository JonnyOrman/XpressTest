using System;
using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenSimpleResultAsserterInitialiser
{
    [Fact]
    public void WhenItInitialisesASimpleAsserterThenItReturnsASimpleAsserter()
    {
        Func<object, object> func = obj => new object(); 
        
        var result = SimpleResultAsserterInitialiser<object>.Initialise(func);

        result.Should().BeOfType<SimpleResultAsserter<object, object>>();
    }
}
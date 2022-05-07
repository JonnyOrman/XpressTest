using FluentAssertions;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenSimpleResultAsserterInitialiser
{
    [Fact]
    public void WhenItInitialisesASimpleAsserterThenItReturnsASimpleAsserter()
    {
        Expression<Func<object, object>> expression = obj => new object();
        
        var result = SimpleResultAsserterInitialiser<object>.Initialise(
            expression,
            null
            );
        
        result.Should().BeOfType<SimpleResultAsserter<object, object>>();
    }
}
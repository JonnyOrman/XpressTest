using System;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenASutPropertyAsserter
{
    [Fact]
    public void WhenItAssertsThatANullPropertyIsNullThenItReturnsASutPropertyTargeter()
    {
        Func<object, object> targetFunc = obj => null;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
            );

        var result = sut.ShouldBeNull();

        result.Should().BeOfType<SutPropertyTargeter<object>>();
    }
    
    [Fact]
    public void WhenItAssertsThatANonNullPropertyIsNullThenItThrowsNullException()
    {
        Func<object, object> targetFunc = obj => new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
        );

        var result = Record.Exception(() => sut.ShouldBeNull());

        result.Should().BeOfType<NullException>();
    }
    
    [Fact]
    public void WhenItAssertsThatAPropertyIsTheExpectedValueThenItReturnsASutPropertyTargeter()
    {
        var expectedValue = new object();
        
        Func<object, object> targetFunc = obj => expectedValue;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
        );

        var result = sut.ShouldBe(expectedValue);

        result.Should().BeOfType<SutPropertyTargeter<object>>();
    }
    
    [Fact]
    public void WhenItAssertsThatAPropertyIsNotTheExpectedValueThenItThrowsEqualException()
    {
        var expectedValue = new object();
        
        Func<object, object> targetFunc = obj => new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
        );

        var result = Record.Exception(() => sut.ShouldBe(expectedValue));

        result.Should().BeOfType<EqualException>();
    }
    
    [Fact]
    public void WhenItAssertsThatAPropertyIsTheExpectedValueFromTheArrangementThenItReturnsASutPropertyTargeter()
    {
        var expectedValue = new object();

        Func<ISutArrangement<object>, object> func = sutArrangement => expectedValue;
        
        Func<object, object> targetFunc = obj => expectedValue;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
        );

        var result = sut.ShouldBe(func);

        result.Should().BeOfType<SutPropertyTargeter<object>>();
    }
    
    [Fact]
    public void WhenItAssertsThatAPropertyIsNotTheExpectedValueFromTheArrangementThenItThrowsEqualException()
    {
        var expectedValue = new object();

        Func<ISutArrangement<object>, object> func = sutArrangement => new object();
        
        Func<object, object> targetFunc = obj => expectedValue;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new SutPropertyAsserter<object, object>(
            targetFunc,
            sutArrangement
        );

        var result = Record.Exception(() => sut.ShouldBe(func));

        result.Should().BeOfType<EqualException>();
    }
}
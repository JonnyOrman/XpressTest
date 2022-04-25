using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyNullAsserter
{
    [Fact]
    public void WhenItAssertsThatAResultPropertyIsNullThenItReturnsTheResultPropertyTargeter()
    {
        var resultPropertyNullComparer = Substitute.For<IResultPropertyNullComparer>();

        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();
        
        var sut = new ResultPropertyNullAsserter<object, object>(
            resultPropertyNullComparer,
            resultPropertyTargeter
            );

        var result = sut.Assert();
        
        resultPropertyNullComparer.Received(1).Compare();

        result.Should().Be(resultPropertyTargeter);
    }
    
    [Fact]
    public void WhenItAssertsThatAResultPropertyIsNotNullThenItThrows()
    {
        var exception = new Exception();
        
        var resultPropertyNullComparer = Substitute.For<IResultPropertyNullComparer>();
        resultPropertyNullComparer
            .When(x => x.Compare())
            .Do(x => throw exception);

        var sut = new ResultPropertyNullAsserter<object, object>(
            resultPropertyNullComparer,
            null
        );

        var result = Record.Exception(() => sut.Assert());

        result.Should().Be(exception);
    }
}
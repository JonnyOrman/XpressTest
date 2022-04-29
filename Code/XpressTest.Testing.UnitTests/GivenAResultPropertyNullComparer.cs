using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultPropertyNullComparer
{
    [Fact]
    public void WhenTheTargetPropertyIsNullThenItAssertsThatItIsNull()
    {
        var testResult = new object();

        Func<object, object> targetFunc = obj => null;

        var sut = new ResultPropertyNullComparer<object, object>(
            testResult,
            targetFunc
            );

        var result = Record.Exception(() => sut.Compare());

        result.Should().BeNull();
    }

    [Fact]
    public void WhenTheTargetPropertyIsNotNullThenItAssertsThatItIsNotNull()
    {
        var testResult = new object();

        Func<object, object> targetFunc = obj => new object();

        var sut = new ResultPropertyNullComparer<object, object>(
            testResult,
            targetFunc
        );

        var result = Record.Exception(() => sut.Compare());

        result.Should().BeOfType<NullException>();
    }
}
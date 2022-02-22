using System;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ExceptionThrowerTests
{
    [Fact]
    public void ThrowsException() =>
        GivenA<ExceptionThrower>
            .WhenIt(sut => sut.ThrowException())
            .ThenItShouldThrow<Exception>();
}
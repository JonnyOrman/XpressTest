﻿using System;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class CalculatorTests
{
    [Fact]
    public void MultiplyNumbers() =>
        GivenA<Calculator>
            .WhenIt().Multiply(3, 2)
            .ThenTheResultShouldBe(6);

    [Fact]
    public void MultiplyNumbers_Example2() =>
        GivenA<Calculator>
            .WhenIt(calculator => calculator.Multiply(3, 2))
            .Then(assertion =>
            {
                Assert.Equal(6, assertion.Result);
            });

    [Fact]
    public void DivideNumbers() =>
        GivenA<Calculator>
            .WhenIt().Divide(6, 3)
            .ThenTheResultShouldBe(2);

    [Fact]
    public void DivideByZero() =>
        GivenA<Calculator>
            .WhenIt(sut => sut.Divide(6, 0))
            .ThenItShouldThrow<DivideByZeroException>();
}
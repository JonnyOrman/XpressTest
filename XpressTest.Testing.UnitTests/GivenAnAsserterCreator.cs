using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnAsserterCreator
{
    [Fact]
    public void WhenItCreatesAVoidAsserterFromASutActionThenTheVoidAsserterIsCreated()
    {
        Action<object> action = obj => { };

        var voidAsserter = Substitute.For<IVoidAsserter<object>>();

        var voidAsserterCreator = Substitute.For<IVoidAsserterCreator<object>>();
        voidAsserterCreator.Create(action).Returns(voidAsserter);
        
        var sut = new AsserterCreator<object>(
            voidAsserterCreator,
            null,
            null
            );

        var result = sut.CreateVoidAsserter(
            action
        );

        result.Should().Be(voidAsserter);
    }
}
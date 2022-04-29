using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidAsserterCreator
{
    [Fact]
    public void WhenItCreatesAnActionVoidAsserterThenItReturnsAVoidAsserter()
    {
        Action<object> action = obj => { };

        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();

        var sut = new VoidAsserterCreator<object>(sutArrangementCreator);

        var result = sut.Create(action);

        result.Should().BeOfType<VoidAsserter<object>>();
    }

    [Fact]
    public void WhenItCreatesASutArrangementActionVoidAsserterThenItReturnsAVoidAsserter()
    {
        Action<ISutArrangement<object>> action = obj => { };

        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();

        var sut = new VoidAsserterCreator<object>(sutArrangementCreator);

        var result = sut.Create(action);

        result.Should().BeOfType<VoidAsserter<object>>();
    }
}
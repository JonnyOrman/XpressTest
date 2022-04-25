using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutPropertyTargeter
{
    [Fact]
    public void WhenItASutPropertyThenItReturnsASutPropertyAsserter()
    {
        Func<object, object> func = obj => new object();

        var arrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new SutPropertyTargeter<object>(arrangement);

        var result = sut.ThenIts(func);

        result.Should().BeOfType<SutPropertyAsserter<object, object>>();
    }
}
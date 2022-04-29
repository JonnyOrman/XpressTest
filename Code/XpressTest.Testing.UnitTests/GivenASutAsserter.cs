using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutAsserter
{
    [Fact]
    public void WhenItAssertsASutPropertyThenItReturnsTheSutPropertyAsserter()
    {
        Func<object, object> func = obj => new object();

        var sutPropertyAsserter = Substitute.For<ISutPropertyAsserter<object, object>>();

        var sutPropertyTargeter = Substitute.For<ISutPropertyTargeter<object>>();
        sutPropertyTargeter.ThenIts(func).Returns(sutPropertyAsserter);

        var sut = new SutAsserter<object>(
            sutPropertyTargeter
            );

        var result = sut.ThenIts(func);

        result.Should().Be(sutPropertyAsserter);
    }
}
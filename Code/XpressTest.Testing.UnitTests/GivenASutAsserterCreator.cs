using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutAsserterCreator
{
    [Fact]
    public void WhenItCreatesASutAsserterThenItReturnsASutAsserter()
    {
        var testSut = new object();

        var arrangement = Substitute.For<ISutArrangement<object>>();
        arrangement.Sut.Returns(testSut);

        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();

        var sut = new SutAsserterCreator<object>(
            sutArrangementCreator
            );

        var result = sut.Create();

        result.Should().BeOfType<SutAsserter<object>>();
    }
}
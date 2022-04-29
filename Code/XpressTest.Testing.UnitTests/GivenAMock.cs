using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMock
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheExpectedPropertyValues()
    {
        var moqMock = new Moq.Mock<object>();

        var sut = new Mock<object>(moqMock);

        sut.MoqMock.Should().Be(moqMock);
        sut.Object.Should().Be(moqMock.Object);
    }
}
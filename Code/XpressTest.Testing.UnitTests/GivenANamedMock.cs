using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMock
{
    [Fact]
    public void WhenItIsConstructedThenItHasThePropertyValuesAreSet()
    {
        var moqMock = new Moq.Mock<object>();

        var name = "MockName";

        var sut = new NamedMock<object>(
            moqMock,
            name
        );

        sut.MoqMock.Should().Be(moqMock);
        sut.Object.Should().Be(moqMock.Object);
        sut.Name.Should().Be(name);
    }
}
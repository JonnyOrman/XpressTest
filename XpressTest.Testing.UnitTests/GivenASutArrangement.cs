using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenASutArrangement
{
    [Fact]
    public void WhenItItConstructedThenItHasTheSut()
    {
        var testSut = new object();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new SutArrangement<object>(
            testSut,
            arrangement
        );

        sut.Sut.Should().Be(testSut);
    }
}
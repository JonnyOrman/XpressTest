using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenSutActionInitialiser
{
    [Fact]
    public void WhenItInitialisesASutActionInitialiserThenItReturnsASutAssserter()
    {
        var result = SutActionInitialiser<object>.Initialise();

        result.Should().BeOfType<SutAsserter<object>>();
    }
}
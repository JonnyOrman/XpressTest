using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnUnnamedObjectTypeAlreadyRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheMessage()
    {
        var message = "ExceptionMessage";
        
        var sut = new UnnamedObjectTypeAlreadyRegisteredException(message);

        sut.Message.Should().Be(message);
    }
}
using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenObjectTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithAnObjectThenItInitialisesAnObjectVariableBuilder()
    {
        var obj = new object();

        var result = ObjectTestInitialiser<object, object>.Initialise(obj);

        result.Should().NotBeNull();
    }
}
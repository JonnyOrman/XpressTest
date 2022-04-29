using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockObjectSetter
{
    [Fact]
    public void WhenItSetsAMockObjectThenItAddsTheMockObjectToTheArrangement()
    {
        var mock = Substitute.For<IMock<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new MockObjectSetter<object>(arrangement);

        sut.Set(mock);

        arrangement.Received(1).Add(mock);
    }
}
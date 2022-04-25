using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockObjectSetter
{
    [Fact]
    public void WhenItSetsANamedMockThenItAddsTheNamedMockToTheArrangement()
    {
        var namedMock = Substitute.For<INamedMock<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new NamedMockObjectSetter<object>(arrangement);
        
        sut.Set(namedMock);
        
        arrangement.Received(1).Add(namedMock);
    }
}
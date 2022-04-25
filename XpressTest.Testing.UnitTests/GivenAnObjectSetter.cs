using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnObjectSetter
{
    [Fact]
    public void WhenItSetsAnObjectThenItAddsTheObjectToTheArrangement()
    {
        var obj = new object();
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new ObjectSetter<object>(arrangement);
        
        sut.Set(obj);
        
        arrangement.Received(1).Add(obj);
    }
}
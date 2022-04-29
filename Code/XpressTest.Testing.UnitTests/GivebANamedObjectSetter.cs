using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivebANamedObjectSetter
{
    [Fact]
    public void WhenItSetsANamedObjectThenItAddsTheNamedObjectToTheArrangement()
    {
        var namedObject = Substitute.For<INamedObject<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new NamedObjectSetter<object>(arrangement);

        sut.Set(namedObject);

        arrangement.Received(1).Add(namedObject);
    }
}
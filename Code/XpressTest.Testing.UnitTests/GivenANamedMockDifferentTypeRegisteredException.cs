using FluentAssertions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockDifferentTypeRegisteredException
{
    [Fact]
    public void WhenItIsConstructedThenItHasTheCorrectProperties()
    {
        var sut = new NamedMockDifferentTypeRegisteredException<object>("MockName", typeof(TestObject));

        sut.Message.Should().Be("Expected mock with name MockName to be of type Object but is actually of type TestObject");
    }
}
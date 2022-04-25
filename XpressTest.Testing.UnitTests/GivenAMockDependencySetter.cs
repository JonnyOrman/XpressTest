using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockDependencySetter
{
    [Fact]
    public void WhenItSetsAMockDependencyThenItAddsItToTheArrangementAsAMockAndAsADependency()
    {
        var moqMock = new Moq.Mock<object>();
        
        var mockDependency = Substitute.For<IMock<object>>();
        mockDependency.MoqMock.Returns(moqMock);
        
        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new MockDependencySetter<object>(
            arrangement
            );
        
        sut.Set(mockDependency);
        
        arrangement.Received(1).Add(mockDependency);
        arrangement.Received(1).AddDependency(moqMock.Object);
    }
}
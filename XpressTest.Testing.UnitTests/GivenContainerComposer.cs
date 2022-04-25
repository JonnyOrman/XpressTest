using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenContainerComposer
{
    [Fact]
    public void WhenItComposesAContainerThenItReturnsTheContainer()
    {
        var result = ContainerComposer<object>.Compose();

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItComposesAContainerWithAnArrangementThenItReturnsTheContainer()
    {
        var arrangement = Substitute.For<IArrangement>();
        
        var result = ContainerComposer<object>.Compose(
            arrangement
            );

        result.Should().NotBeNull();
    }
}
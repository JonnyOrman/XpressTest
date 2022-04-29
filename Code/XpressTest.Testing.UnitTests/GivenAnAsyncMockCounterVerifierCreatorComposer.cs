using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAnAsyncMockCounterVerifierCreatorComposer
{
    [Fact]
    public void
        WhenItComposesAMockCountVerifierCreatorForAMockTypeThenItComposesAMockCountVerifierCreator()
    {
        var asserter = new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new AsyncMockCounterVerifierCreatorComposer<object, object>(
            sutArrangement
            );

        var result = sut.Compose<object>(
            asserter
            );

        result.Should().NotBeNull();
    }

    [Fact]
    public void
        WhenItComposesAMockCountVerifierCreatorForAMockThenItComposesAMockCountVerifierCreator()
    {
        var mock = Substitute.For<IMock<object>>();

        var asserter = new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new AsyncMockCounterVerifierCreatorComposer<object, object>(
            sutArrangement
        );

        var result = sut.Compose(
            mock,
            asserter
        );

        result.Should().NotBeNull();
    }
}
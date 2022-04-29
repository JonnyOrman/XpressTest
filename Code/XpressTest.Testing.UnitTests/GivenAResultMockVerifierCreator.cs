using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultMockVerifierCreator
{
    [Fact]
    public void WhenItCreatesAnAsyncResultMockVerifierForAMockTypeThenItReturnsAnAsyncResultMockVerifier()
    {
        var asserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var mockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IResultAsserter<object, object>>>();

        var asyncMockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IAsyncResultAsserter<object, object>>>();

        var sut = new ResultMockVerifierCreator<object, object>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
            );

        var result = sut.Create<object>(asserter);

        result.Should().BeOfType<AsyncResultMockVerifier<object, object, object>>();
    }

    [Fact]
    public void WhenItCreatesAnAsyncResultMockVerifierForAMockThenItReturnsAnAsyncResultMockVerifier()
    {
        var mock = Substitute.For<IMock<object>>();

        var asserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var mockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IResultAsserter<object, object>>>();

        var asyncMockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IAsyncResultAsserter<object, object>>>();

        var sut = new ResultMockVerifierCreator<object, object>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );

        var result = sut.Create(
            mock,
            asserter
            );

        result.Should().BeOfType<AsyncResultMockVerifier<object, object, object>>();
    }

    [Fact]
    public void WhenItCreatesAResultMockVerifierForAMockThenItReturnsAnAsyncResultMockVerifier()
    {
        var mock = Substitute.For<IMock<object>>();

        var asserter = Substitute.For<IResultAsserter<object, object>>();

        var mockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IResultAsserter<object, object>>>();

        var asyncMockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IAsyncResultAsserter<object, object>>>();

        var sut = new ResultMockVerifierCreator<object, object>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );

        var result = sut.Create(
            mock,
            asserter
        );

        result.Should().BeOfType<ResultMockVerifier<object, object, object>>();
    }
}
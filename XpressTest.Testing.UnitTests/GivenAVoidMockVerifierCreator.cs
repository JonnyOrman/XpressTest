using NSubstitute;
using Xunit;
using FluentAssertions;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidMockVerifierCreator
{
    [Fact]
    public void WhenItCreatesAMockTypeVoidMockVerifierThenItReturnsAVoidMockVerifier()
    {
        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IVoidAsserter<object>>>();

        var asserter = Substitute.For<IVoidAsserter<object>>();
        
        var mockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IVoidAsserter<object>>>();
        mockCounterVerifierCreatorComposer.Compose<object>(asserter).Returns(mockCountVerifierCreator);

        var sut = new VoidMockVerifierCreator<object>(
            mockCounterVerifierCreatorComposer
            );

        var result = sut.Create<object>(asserter);

        result.Should().BeOfType<VoidMockVerifier<object, object>>();
    }
    
    [Fact]
    public void WhenItCreatesAMockVoidMockVerifierThenItReturnsAVoidMockVerifier()
    {
        var mock = Substitute.For<IMock<object>>();
        
        var mockCountVerifierCreator = Substitute.For<IMockCountVerifierCreator<object, IVoidAsserter<object>>>();

        var asserter = Substitute.For<IVoidAsserter<object>>();
        
        var mockCounterVerifierCreatorComposer = Substitute.For<IMockCountVerifierCreatorComposer<IVoidAsserter<object>>>();
        mockCounterVerifierCreatorComposer.Compose(mock, asserter).Returns(mockCountVerifierCreator);

        var sut = new VoidMockVerifierCreator<object>(
            mockCounterVerifierCreatorComposer
        );

        var result = sut.Create(mock, asserter);

        result.Should().BeOfType<VoidMockVerifier<object, object>>();
    }
}
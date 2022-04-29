using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenANamedMockSetupBuilderCreator
{
    [Fact]
    public void WhenItCreatesANamedMockSetupBuilderThenItReturnsANamedMockSetupBuilder()
    {
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var sut = new NamedMockSetupBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderCreator
            );

        var result = sut.Create<object>("MockName");

        result.Should().BeOfType<MockSetupBuilder<object, object, INamedMock<object>>>();
    }
}
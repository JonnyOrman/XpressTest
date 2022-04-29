using FluentAssertions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenTheTestInitialiser
{
    [Fact]
    public void WhenItInitialisesATestWithANamedMockThenItInitialisesAMockSetupBuilder()
    {
        var result = GivenA<object>.AndGivenA<object>("Name");

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAMockThenItInitialisesAMockSetupBuilder()
    {
        var result = GivenA<object>.AndGivenA<object>();

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithANamedVariableThenItInitialisesAVariableBuilder()
    {
        var result = GivenA<object>.AndGiven(
            new object(),
            "Name"
            );

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAVariableThenItInitialisesAVariableBuilder()
    {
        var result = GivenA<object>.AndGiven(
            new object()
        );

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAMockDependencyThenItInitialisesAMockDependencySetupBuilder()
    {
        var result = GivenA<object>.WithA<object>();

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAnObjectDependencyThenItInitialisesADependencyBuilder()
    {
        var result = GivenA<object>.With(new object());

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithANamedObjectDependencyThenItInitialisesADependencyBuilder()
    {
        var result = GivenA<object>.With(
            new object(),
            "Name"
            );

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAnActionThenItInitialisesAnExceptionAsserter()
    {
        var result = GivenA<object>.WhenIt(sut => { });

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithAFuncThenItInitialisesASimpleResultAsserter()
    {
        var result = GivenA<object>.WhenIt(sut => new object());

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestWithNoSetupThenItActivatesTheSut()
    {
        var result = GivenA<object>.WhenIt();

        result.Should().NotBeNull();
    }

    [Fact]
    public void WhenItInitialisesATestByConstructingTheSutThenItReturnsASutPropertyTargeter()
    {
        var result = GivenA<object>.WhenItIsConstructed();

        result.Should().NotBeNull();
    }
}
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class VoidTwoValuesAndMockDependencyClassTests
{
    [Fact]
    public void Constructor1_Example1() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .With("Parameter1Value", "Parameter1")
            .With("Parameter2Value", "Parameter2")
            .WithA<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
                .Should(voidMock => voidMock.Execute("Parameter1Value", "Parameter2Value"))
                .Once();

    [Fact]
    public void Constructor1_Example2() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter1Value", "Parameter1")
                .AndGiven("Parameter2Value", "Parameter2")
            .WithThe<string>("Parameter1")
            .WithThe<string>("Parameter2")
            .WithA<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
                .Should(arrangement => voidMock => voidMock.Execute(
                    arrangement.GetThe<string>("Parameter1"),
                    arrangement.GetThe<string>("Parameter2")))
                .Once();

    [Fact]
    public void Constructor1_Example3() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter1Value", "Parameter1")
                .AndGiven("Parameter2Value", "Parameter2")
                .AndGivenA<IVoidMockTwoValueParameter>()
            .WithThe<string>("Parameter1")
            .WithThe<string>("Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
                .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>("Parameter2")))
                .Once();

    [Fact]
    public void Constructor1_Example4() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
            .With("Parameter1Value", "Parameter1")
            .With("Parameter2Value", "Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(voidMock => voidMock.Execute(
                "Parameter1Value",
                "Parameter2Value"))
            .Once();

    [Fact]
    public void Constructor1_Example5() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter1Value")
                .AndGiven("Parameter2Value", "Parameter2")
                .AndGivenA<IVoidMockTwoValueParameter>()
            .WithThe<string>()
            .WithThe<string>("Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                    arrangement.GetThe<string>(),
                    arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor1_Example6() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter1Value", "Parameter1")
                .AndGiven("Parameter2Value")
                .AndGivenA<IVoidMockTwoValueParameter>()
            .WithThe<string>("Parameter1")
            .WithThe<string>()
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>()))
            .Once();

    [Fact]
    public void Constructor1_Example7() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
                .AndGiven("Parameter2Value", "Parameter2")
            .With<string>("Parameter1Value")
            .WithThe<string>("Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>(),
                arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor1_Example8() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
                .AndGiven("Parameter1Value")
            .WithThe<string>()
            .With<string>("Parameter2Value", "Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>(),
                arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor1_Example9() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
                .AndGiven("Parameter2Value")
            .With<string>("Parameter1Value", "Parameter1")
            .WithThe<string>()
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>()))
            .Once();

    [Fact]
    public void Constructor1_Example10() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
                .AndGiven("Parameter2Value", "Parameter2")
            .With<string>("Parameter1Value", "Parameter1")
            .WithThe<string>("Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor1_Example11() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter2Value", "Parameter2")
            .With<string>("Parameter1Value", "Parameter1")
            .WithThe<string>("Parameter2")
            .WithA<IVoidMockTwoValueParameter>("MockParameter")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor1_Example12() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .With<string>("Parameter1Value", "Parameter1")
            .With<string>("Parameter2Value", "Parameter2")
            .WithA<IVoidMockTwoValueParameter>("MockParameter")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
            .Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>("Parameter2")))
            .Once();

    [Fact]
    public void Constructor2_Example1() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .WithA<IVoidMockTwoValueParameter>()
            .With("Parameter1Value", "Parameter1")
            .With("Parameter2Value", "Parameter2")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>()
                .Should(voidMock => voidMock.Execute("Parameter1Value", "Parameter2Value"))
                .Once();

    [Fact]
    public void Constructor2_Example2() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGiven("Parameter1Value", "Parameter1")
                .AndGiven("Parameter2Value", "Parameter2")
            .WithA<IVoidMockTwoValueParameter>()
            .WithThe<string>("Parameter1")
            .WithThe<string>("Parameter2")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>().Should(arrangement => voidMock => voidMock.Execute(
                    arrangement.GetThe<string>("Parameter1"),
                    arrangement.GetThe<string>("Parameter2")))
                .Once();

    [Fact]
    public void Constructor2_Example3() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
                .AndGivenA<IVoidMockTwoValueParameter>()
                .AndGiven("Parameter1Value", "Parameter1")
                .AndGiven("Parameter2Value", "Parameter2")
            .WithTheMock<IVoidMockTwoValueParameter>()
            .WithThe<string>("Parameter1")
            .WithThe<string>("Parameter2")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .ThenThe<IVoidMockTwoValueParameter>().Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetThe<string>("Parameter1"),
                arrangement.GetThe<string>("Parameter2"))).Once();
}
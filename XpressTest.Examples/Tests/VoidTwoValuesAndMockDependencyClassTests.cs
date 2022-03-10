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
            .Then<IVoidMockTwoValueParameter>().Should(voidMock => voidMock.Execute("Parameter1Value", "Parameter2Value")).Once();
    
    [Fact]
    public void Constructor1_Example2() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .AndGiven("Parameter1Value", "Parameter1")
            .AndGiven("Parameter2Value", "Parameter2")
            .With<string>("Parameter1")
            .With<string>("Parameter2")
            .WithA<IVoidMockTwoValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockTwoValueParameter>().Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetObject<string>("Parameter1"),
                arrangement.GetObject<string>("Parameter2"))).Once();
    
    [Fact]
    public void Constructor2_Example1() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .WithA<IVoidMockTwoValueParameter>()
            .With("Parameter1Value", "Parameter1")
            .With("Parameter2Value", "Parameter2")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockTwoValueParameter>().Should(voidMock => voidMock.Execute("Parameter1Value", "Parameter2Value")).Once();
    
    [Fact]
    public void Constructor2_Example2() =>
        GivenA<VoidTwoValuesAndMockDependencyClass>
            .AndGiven("Parameter1Value", "Parameter1")
            .AndGiven("Parameter2Value", "Parameter2")
            .WithA<IVoidMockTwoValueParameter>()
            .WithNamedObject<string>("Parameter1")
            .With<string>("Parameter2")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockTwoValueParameter>().Should(arrangement => voidMock => voidMock.Execute(
                arrangement.GetObject<string>("Parameter1"),
                arrangement.GetObject<string>("Parameter2"))).Once();
}
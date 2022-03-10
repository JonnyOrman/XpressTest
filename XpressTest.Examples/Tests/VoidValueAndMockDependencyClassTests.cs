using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class VoidValueAndMockDependencyClassTests
{
    [Fact]
    public void Constructor1_Example1() =>
        GivenA<VoidValueAndMockDependencyClass>
            .With("ParameterValue")
            .WithA<IVoidMockOneValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockOneValueParameter>().Should(voidMock => voidMock.Execute("ParameterValue")).Once();
    
    [Fact]
    public void Constructor1_Example2() =>
        GivenA<VoidValueAndMockDependencyClass>
            .AndGiven("ParameterValue")
            .With<string>()
            .WithA<IVoidMockOneValueParameter>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockOneValueParameter>().Should(arrangement => voidMock => voidMock.Execute(arrangement.GetThe<string>())).Once();
    
    [Fact]
    public void Constructor2_Example1() =>
        GivenA<VoidValueAndMockDependencyClass>
            .WithA<IVoidMockOneValueParameter>()
            .With("ParameterValue")
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockOneValueParameter>().Should(voidMock => voidMock.Execute("ParameterValue")).Once();
    
    [Fact]
    public void Constructor2_Example2() =>
        GivenA<VoidValueAndMockDependencyClass>
            .AndGiven("ParameterValue")
            .WithA<IVoidMockOneValueParameter>()
            .With<string>()
            .WhenIt(voidValueAndMockDependencyClass => voidValueAndMockDependencyClass.Execute())
            .Then<IVoidMockOneValueParameter>().Should(arrangement => voidMock => voidMock.Execute(arrangement.GetThe<string>())).Once();
}
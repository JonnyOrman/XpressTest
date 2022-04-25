using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVariableBuilderCreator
{
    [Fact]
    public void WhenItCreatesAnObjectVariableBuilderThenItReturnsAVariableBuilder()
    {
        var obj = new object();

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var sut = new VariableBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderCreator,
            namedMockSetupBuilderCreator
        );

        var result = sut.Create(obj);

        result.Should().BeOfType<VariableBuilder<object, object, IVariableBuilderChainer<object>>>();
    }

    [Fact]
    public void WhenItCreatesANamedObjectVariableBuilderThenItReturnsAVariableBuilder()
    {
        var obj = new object();

        var name = "ObjectName";

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var sut = new VariableBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderCreator,
            namedMockSetupBuilderCreator
        );

        var result = sut.Create(obj, name);

        result.Should().BeOfType<VariableBuilder<object, INamedObject<object>, IVariableBuilderChainer<object>>>();
    }

    [Fact]
    public void WhenItCreatesAnObjectVariableBuilderFromAnArrangementFuncThenItReturnsAVariableBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var sut = new VariableBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderCreator,
            namedMockSetupBuilderCreator
        );

        var result = sut.Create(func);

        result.Should().BeOfType<VariableBuilder<object, object, IVariableBuilderChainer<object>>>();
    }
    
    [Fact]
    public void WhenItCreatesANamedObjectVariableBuilderFromAnArrangementFuncThenItReturnsAVariableBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var name = "ObjectName";

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();

        var sut = new VariableBuilderCreator<object>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderCreator,
            namedMockSetupBuilderCreator
        );

        var result = sut.Create(func, name);

        result.Should().BeOfType<VariableBuilder<object, INamedObject<object>, IVariableBuilderChainer<object>>>();
    }
}
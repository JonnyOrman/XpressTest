using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVariableBuilderChainer
{
    [Fact]
    public void WhenItStartsANewNamedObjectBuilderThenItCreatesANewNamedObjectVariableBuilder()
    {
        var newObject = new object();

        var objectName = "ObjectName";

        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var variableBuilderCreator = Substitute.For<IVariableBuilderCreator<object>>();
        variableBuilderCreator.Create(newObject, objectName).Returns(variableBuilder);

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.VariableBuilderCreator.Returns(variableBuilderCreator);

        var sut = new VariableBuilderChainer<object>(
            testBuilderContainer,
            null,
            null
            );

        var result = sut.StartNewNamedObjectBuilder(
            newObject,
            objectName
        );

        result.Should().Be(variableBuilder);
    }

    [Fact]
    public void WhenItStartsANewNamedObjectBuilderWithAnArrangementFuncThenItCreatesANewNamedObjectVariableBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var objectName = "ObjectName";

        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var variableBuilderCreator = Substitute.For<IVariableBuilderCreator<object>>();
        variableBuilderCreator.Create(func, objectName).Returns(variableBuilder);

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.VariableBuilderCreator.Returns(variableBuilderCreator);

        var sut = new VariableBuilderChainer<object>(
            testBuilderContainer,
            null,
            null
        );

        var result = sut.StartNewNamedObjectBuilder(
            func,
            objectName
        );

        result.Should().Be(variableBuilder);
    }

    [Fact]
    public void WhenItStartsANewObjectBuilderThenItCreatesANewNamedObjectVariableBuilder()
    {
        var newObject = new object();

        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var variableBuilderCreator = Substitute.For<IVariableBuilderCreator<object>>();
        variableBuilderCreator.Create(newObject).Returns(variableBuilder);

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.VariableBuilderCreator.Returns(variableBuilderCreator);

        var sut = new VariableBuilderChainer<object>(
            testBuilderContainer,
            null,
            null
        );

        var result = sut.StartNewObjectBuilder(
            newObject
        );

        result.Should().Be(variableBuilder);
    }

    [Fact]
    public void WhenItStartsANewObjectBuilderFromAnArrangementFuncThenItCreatesANewNamedObjectVariableBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var variableBuilderCreator = Substitute.For<IVariableBuilderCreator<object>>();
        variableBuilderCreator.Create(func).Returns(variableBuilder);

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.VariableBuilderCreator.Returns(variableBuilderCreator);

        var sut = new VariableBuilderChainer<object>(
            testBuilderContainer,
            null,
            null
        );

        var result = sut.StartNewObjectBuilder(
            func
        );

        result.Should().Be(variableBuilder);
    }

    [Fact]
    public void WhenItStartsANewMockObjectBuilderThenItCreatesANewMockObjectBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();

        var mockSetupBuilderCreator = Substitute.For<IMockSetupBuilderCreator<object>>();
        mockSetupBuilderCreator.Create<object>().Returns(mockSetupBuilder);

        var sut = new VariableBuilderChainer<object>(
            null,
            mockSetupBuilderCreator,
            null
        );

        var result = sut.StartNewMockObjectBuilder<object>();

        result.Should().Be(mockSetupBuilder);
    }

    [Fact]
    public void WhenItStartsAnExistingObjectDependencyBuilderFromTheArrangementThenItCreatesANewObjectDependencyBuilder()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateObjectDependencyBuilder(func).Returns(dependencyBuilder);

        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);

        var sut = new VariableBuilderChainer<object>(
            testBuilderContainer,
            null,
            null
        );

        var result = sut.StartExistingObjectDependencyBuilder(func);

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenItStartsAnNewNamedMockObjectBuilderThenItCreatesANewNamedMockObjectBuilder()
    {
        var name = "MockName";

        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();

        var namedMockSetupBuilderCreator = Substitute.For<INamedMockSetupBuilderCreator<object>>();
        namedMockSetupBuilderCreator.Create<object>(name).Returns(mockSetupBuilder);

        var sut = new VariableBuilderChainer<object>(
            null,
            null,
            namedMockSetupBuilderCreator
        );

        var result = sut.StartNewNamedMockObjectBuilder<object>(name);

        result.Should().Be(mockSetupBuilder);
    }
}
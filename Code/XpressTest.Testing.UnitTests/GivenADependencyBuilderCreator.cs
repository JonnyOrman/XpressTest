using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependencyBuilderCreator
{
    [Fact]
    public void WhenItCreatesAnObjectDependencyBuilderWithANameThenANamedDependencyBuilderIsCreated()
    {
        var dependency = new object();

        var dependencyName = "DependencyName";

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var namedDependencyBuilderCreator = Substitute.For<INamedDependencyBuilderCreator<object>>();
        namedDependencyBuilderCreator.Create(dependency, dependencyName).Returns(dependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            namedDependencyBuilderCreator,
            null,
            null,
            null
            );

        var result = sut.CreateObjectDependencyBuilder(
            dependency,
            dependencyName
            );

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenItCreatesAMockDependencyBuilderThenAMockDependencyBuilderIsCreated()
    {
        var mockDependencyBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var mockTypeDependencyBuilderCreator = Substitute.For<IMockTypeDependencyBuilderCreator<object>>();
        mockTypeDependencyBuilderCreator.Create<object>().Returns(mockDependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            null,
            mockTypeDependencyBuilderCreator,
            null,
            null
        );

        var result = sut.CreateMockDependencyBuilder<object>();

        result.Should().Be(mockDependencyBuilder);
    }

    [Fact]
    public void WhenItCreatesAnObjectDependencyBuilderThenAnObjectDependencyBuilderIsCreated()
    {
        var dependency = new object();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectDependencyBuilderCreator = Substitute.For<IObjectDependencyBuilderCreator<object>>();
        objectDependencyBuilderCreator.Create(dependency).Returns(dependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            objectDependencyBuilderCreator,
            null,
            null,
            null,
            null
        );

        var result = sut.CreateObjectDependencyBuilder(
            dependency
            );

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenItCreatesAnObjectDependencyBuilderFromAnArrangementFuncThenAnObjectDependencyBuilderIsCreated()
    {
        Func<IReadArrangement, object> func = arrangement => new object();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectDependencyBuilderCreator = Substitute.For<IObjectDependencyBuilderCreator<object>>();
        objectDependencyBuilderCreator.Create(func).Returns(dependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            objectDependencyBuilderCreator,
            null,
            null,
            null,
            null
        );

        var result = sut.CreateObjectDependencyBuilder(
            func
        );

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenItCreatesAMockDependencyBuilderWithANameThenANamedMockDependencyBuilderIsCreated()
    {
        var name = "MockName";

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var namedMockDependencyBuilderCreator = Substitute.For<INamedMockDependencyBuilderCreator<object>>();
        namedMockDependencyBuilderCreator.Create<object>(name).Returns(mockDependencySetupBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            null,
            null,
            namedMockDependencyBuilderCreator,
            null
        );

        var result = sut.CreateMockDependencyBuilder<object>(
            name
        );

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void WhenItCreatesAnExistingMockDependencyBuilderThenAnExistingMockDependencyBuilderIsCreated()
    {
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var mockTypeDependencyBuilderCreator = Substitute.For<IMockTypeDependencyBuilderCreator<object>>();
        mockTypeDependencyBuilderCreator.CreateExisting<object>().Returns(mockDependencySetupBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            null,
            mockTypeDependencyBuilderCreator,
            null,
            null
        );

        var result = sut.CreateExistingMockDependencyBuilder<object>();

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void WhenItCreatesAnExistingObjectDependencyBuilderThenAnExistingObjectDependencyBuilderIsCreated()
    {
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var existingObjectDependencyBuilderCreator = Substitute.For<IExistingObjectDependencyBuilderCreator<object>>();
        existingObjectDependencyBuilderCreator.Create<object>().Returns(dependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            null,
            null,
            null,
            existingObjectDependencyBuilderCreator
        );

        var result = sut.Create<object>();

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenItCreatesAnExistingObjectDependencyBuilderWithANameThenAnExistingObjectDependencyBuilderWithANameIsCreated()
    {
        var name = "DependencyName";

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var existingObjectDependencyBuilderCreator = Substitute.For<IExistingObjectDependencyBuilderCreator<object>>();
        existingObjectDependencyBuilderCreator.Create<object>(name).Returns(dependencyBuilder);

        var sut = new DependencyBuilderCreator<object>(
            null,
            null,
            null,
            null,
            existingObjectDependencyBuilderCreator
        );

        var result = sut.Create<object>(
            name
            );

        result.Should().Be(dependencyBuilder);
    }
}
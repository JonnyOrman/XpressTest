using FluentAssertions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependencyBuilder
{
    [Fact]
    public void WhenTheSutIsConstructedThenTheExistingDependencyIsSetAndASutAsserterIsStarted()
    {
        var sutPropertyTargeter = Substitute.For<ISutPropertyTargeter<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartSutAsserter().Returns(sutPropertyTargeter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenItIsConstructed();

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(sutPropertyTargeter);
    }

    [Fact]
    public void WhenASutActionIsExecutedThenTheExistingDependencyIsSetAndAVoidAsserterIsStarted()
    {
        var voidAsserter = Substitute.For<IVoidAsserter<object>>();

        Action<object> action = obj => { };

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartVoidAsserter(action).Returns(voidAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenIt(action);

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(voidAsserter);
    }

    [Fact]
    public void WhenANewMockDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewMockDependencyBuilderIsStarted()
    {
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WithA<object>();

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void
        WhenANewNamedMockDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewNamedMockDependencyBuilderIsStarted()
    {
        var dependencyName = "DependencyName";

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewMockDependencyBuilder<object>(dependencyName)
            .Returns(mockDependencySetupBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WithA<object>(dependencyName);

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void WhenANewDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewDependencyBuilderIsStarted()
    {
        var newDependency = new object();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewObjectDependencyBuilder(newDependency).Returns(dependencyBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.With(newDependency);

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenAnExistingMockDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewExistingMockDependencyBuilderIsStarted()
    {
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewExistingMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WithTheMock<object>();

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(mockDependencySetupBuilder);
    }

    [Fact]
    public void WhenAnExistingNamedObjectDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewExistingObjectBuilderIsStarted()
    {
        var objectName = "ObjectName";

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewExistingObjectDependencyBuilder<object>(objectName).Returns(dependencyBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WithThe<object>(objectName);

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenAnExistingObjectDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewExistingObjectBuilderIsStarted()
    {
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewExistingObjectDependencyBuilder<object>().Returns(dependencyBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WithThe<object>();

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenANewNamedObjectDependencyIsRegisteredThenTheExistingDependencyIsSetAndANewDependencyBuilderIsStarted()
    {
        var newDependency = new object();

        var dependencyName = "DependencyName";

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartNewObjectDependencyBuilder(newDependency, dependencyName).Returns(dependencyBuilder);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.With(
            newDependency,
            dependencyName
            );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(dependencyBuilder);
    }

    [Fact]
    public void WhenAnArrangementActionIsExecutedThenTheExistingDependencyIsSetAndAVoidAsserterIsStarted()
    {
        Action<ISutArrangement<object>> action = arrangement => { };

        var voidAsserter = Substitute.For<IVoidAsserter<object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartVoidAsserter(action).Returns(voidAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenIt(
            action
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(voidAsserter);
    }

    [Fact]
    public void WhenAnArrangementFuncIsExecutedThenTheExistingDependencyIsSetAndAResultAsserterIsStarted()
    {
        Func<ISutArrangement<object>, object> func = arrangement => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartResultAsserter(func).Returns(resultAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenIt(
            func
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(resultAsserter);
    }

    [Fact]
    public void WhenAFuncArrangementFuncIsExecutedThenTheExistingDependencyIsSetAndAResultAsserterIsStarted()
    {
        Func<IReadArrangement, Func<object, object>> func = arrangement => obj => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartResultAsserter(func).Returns(resultAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenIt(
            func
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(resultAsserter);
    }

    [Fact]
    public void WhenAFuncIsExecutedThenTheExistingDependencyIsSetAndAResultAsserterIsStarted()
    {
        Func<object, object> func = obj => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartResultAsserter(func).Returns(resultAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenIt(
            func
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(resultAsserter);
    }

    [Fact]
    public void WhenAnAsyncArrangementFuncIsExecutedThenTheExistingDependencyIsSetAndAnAsyncResultAsserterIsStarted()
    {
        Func<ISutArrangement<object>, Task<object>> func = arrangement => Task.FromResult(new object());

        var asyncResultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartAsyncResultAsserter(func).Returns(asyncResultAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenItAsync(
            func
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(asyncResultAsserter);
    }

    [Fact]
    public void WhenAnAsyncFuncIsExecutedThenTheExistingDependencyIsSetAndAnAsyncResultAsserterIsStarted()
    {
        Func<object, Task<object>> func = obj => Task.FromResult(new object());

        var asyncResultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var dependency = new object();

        var arrangementSetter = Substitute.For<IArrangementSetter<object>>();

        var dependencyBuilderChainer = Substitute.For<IDependencyBuilderChainer<object>>();
        dependencyBuilderChainer.StartAsyncResultAsserter(func).Returns(asyncResultAsserter);

        var sut = new DependencyBuilder<object, object>(
            dependency,
            arrangementSetter,
            dependencyBuilderChainer
        );

        var result = sut.WhenItAsync(
            func
        );

        arrangementSetter.Received(1).Set(dependency);

        result.Should().Be(asyncResultAsserter);
    }
}
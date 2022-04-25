using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVariableBuilder
{
    [Fact]
    public void WhenItBuildsANewMockThenItSetsTheCurrentObjectAndStartsANewMockObjectBuilder()
    {
        var currentObject = new object();

        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewMockObjectBuilder<object>().Returns(mockSetupBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
            );

        var result = sut.AndGivenA<object>();
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(mockSetupBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewObjectThenItSetsTheCurrentObjectAndStartsANewObjectBuilder()
    {
        var currentObject = new object();

        var newObject = new object();
        
        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewObjectBuilder(newObject).Returns(variableBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.AndGiven(newObject);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(variableBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewNamedObjectThenItSetsTheCurrentObjectAndStartsANewObjectBuilder()
    {
        var currentObject = new object();

        var newObject = new object();

        var newObjectName = "ObjectName";
        
        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewNamedObjectBuilder(newObject, newObjectName).Returns(variableBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.AndGiven(newObject, newObjectName);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(variableBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewObjectFromTheArrangementThenItSetsTheCurrentObjectAndStartsANewObjectBuilder()
    {
        var currentObject = new object();

        var newObject = new object();

        Func<IReadArrangement, object> newObjectFunc = arrangement => newObject;
        
        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewObjectBuilder(newObjectFunc).Returns(variableBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.AndGiven(newObjectFunc);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(variableBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewNamedObjectFromTheArrangementThenItSetsTheCurrentObjectAndStartsANewNamedObjectBuilder()
    {
        var currentObject = new object();

        var newObject = new object();

        var newObjectName = "ObjectName";

        Func<IReadArrangement, object> newObjectFunc = arrangement => newObject;
        
        var variableBuilder = Substitute.For<IVariableBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewNamedObjectBuilder(newObjectFunc, newObjectName).Returns(variableBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.AndGiven(newObjectFunc, newObjectName);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(variableBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewExistingNamedObjectThenItSetsTheCurrentObjectAndStartsANewExistingObjectDependencyBuilder()
    {
        var currentObject = new object();

        var newObjectName = "ObjectName";

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewExistingObjectDependencyBuilder<object>(newObjectName).Returns(dependencyBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WithThe<object>(newObjectName);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItBuildsAnExistingMockThenItSetsTheCurrentObjectAndStartsANewExistingMockDependencyBuilder()
    {
        var currentObject = new object();

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewExistingMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WithTheMock<object>();
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(mockDependencySetupBuilder);
    }
    
    [Fact]
    public void WhenItPerformsSutArrangementFuncThenItSetsTheCurrentObjectAndStartsAResultBuilder()
    {
        var currentObject = new object();

        Func<ISutArrangement<object>, object> func = arrangement => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartResultAsserter(func).Returns(resultAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenIt<object>(func);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenItPerformsReadArrangementFuncThenItSetsTheCurrentObjectAndStartsAResultBuilder()
    {
        var currentObject = new object();

        Func<IReadArrangement, Func<object, object>> func = arrangement => obj => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartResultAsserter(func).Returns(resultAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenIt<object>(func);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenItPerformsSutArrangementActionThenItSetsTheCurrentObjectAndStartsAVoidBuilder()
    {
        var currentObject = new object();

        Action<ISutArrangement<object>> action = arrangement => { };

        var voidAsserter = Substitute.For<IVoidAsserter<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartVoidAsserter(action).Returns(voidAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenIt(action);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(voidAsserter);
    }
    
    [Fact]
    public void WhenItBuildsANewMockDependencyThenItSetsTheCurrentObjectAndStartsANewMockDependencyBuilder()
    {
        var currentObject = new object();

        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WithA<object>();
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(mockDependencySetupBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewObjectDependencyThenItSetsTheCurrentObjectAndStartsANewMockDependencyBuilder()
    {
        var currentObject = new object();

        var newDependency = new object();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewObjectDependencyBuilder(newDependency).Returns(dependencyBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.With<object>(newDependency);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItBuildsAnExistingObjectDependencyThenItSetsTheCurrentObjectAndStartsANewExistingObjectDependencyBuilder()
    {
        var currentObject = new object();
        
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewExistingObjectDependencyBuilder<object>().Returns(dependencyBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WithThe<object>();
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewNamedObjectDependencyThenItSetsTheCurrentObjectAndStartsANewObjectDependencyBuilder()
    {
        var currentObject = new object();

        var newDependency = new object();

        var newDependencyName = "DependencyName";
        
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewObjectDependencyBuilder(newDependency, newDependencyName).Returns(dependencyBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.With(
            newDependency,
            newDependencyName
            );
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewDependencyFromTheArrangementThenItSetsTheCurrentObjectAndStartsANewValueDependencyBuilder()
    {
        var currentObject = new object();

        Func<IReadArrangement, object> func = arrangement => new object();
            
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartExistingObjectDependencyBuilder(func).Returns(dependencyBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.With(
            func
        );
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItBuildsANewNamedMockDependencyThenItSetsTheCurrentObjectAndStartsANewNamedMockObjectBuilder()
    {
        var currentObject = new object();

        var name = "DependencyName";
        
        var mockSetupBuilder = Substitute.For<IMockSetupBuilder<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartNewNamedMockObjectBuilder<object>(name).Returns(mockSetupBuilder);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.AndGivenA<object>(
            name
        );
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(mockSetupBuilder);
    }
    
    [Fact]
    public void WhenItPerformsSutActionThenItSetsTheCurrentObjectAndStartsANewVoidAsserter()
    {
        var currentObject = new object();

        Action<object> action = obj => { };
        
        var voidAsserter = Substitute.For<IVoidAsserter<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartVoidAsserter(action).Returns(voidAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenIt(action);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(voidAsserter);
    }
    
    [Fact]
    public void WhenItPerformsSutFuncThenItSetsTheCurrentObjectAndStartsANewResultAsserter()
    {
        var currentObject = new object();

        Func<object, object> func = obj => new object();
        
        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartResultAsserter(func).Returns(resultAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenIt(func);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenItPerformsAsyncSutArrangementFuncThenItSetsTheCurrentObjectAndStartsANewAsyncResultAsserter()
    {
        var currentObject = new object();

        Func<ISutArrangement<object>, Task<object>> func = async arrangement => new object();
        
        var resultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartAsyncResultAsserter(func).Returns(resultAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenItAsync(func);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenItPerformsAsyncSutFuncThenItSetsTheCurrentObjectAndStartsANewAsyncResultAsserter()
    {
        var currentObject = new object();

        Func<object, Task<object>> func = async obj => new object();
        
        var resultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartAsyncResultAsserter(func).Returns(resultAsserter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenItAsync(func);
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenTheSutIsConstructedThenItSetsTheCurrentObjectAndStartsANewSutPropertyTargeter()
    {
        var currentObject = new object();

        var sutPropertyTargeter = Substitute.For<ISutPropertyTargeter<object>>();

        var objectSetter = Substitute.For<IArrangementSetter<object>>();

        var chainer = Substitute.For<IVariableBuilderChainer<object>>();
        chainer.StartSutAsserter().Returns(sutPropertyTargeter);
        
        var sut = new VariableBuilder<object, object, IVariableBuilderChainer<object>>(
            currentObject,
            objectSetter,
            chainer
        );

        var result = sut.WhenItIsConstructed();
        
        objectSetter.Received(1).Set(currentObject);

        result.Should().Be(sutPropertyTargeter);
    }
}
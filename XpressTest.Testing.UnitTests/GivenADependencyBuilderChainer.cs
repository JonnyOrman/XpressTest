using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenADependencyBuilderChainer
{
    [Fact]
    public void WhenItStartsAMockResultDependencyBuilderThenAMockResultDependencyBuilderIsReturned()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var mock = Substitute.For<IMock<object>>();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new DependencyBuilderChainer<object>(
            arrangement,
            null
            );

        var result = sut.StartMockResultDependencyBuilder(
            expression,
            mock,
            dependencyBuilder
        );

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItStartsAMockAsyncResultDependencyBuilderWithAnArrangementFuncThenAMockAsyncResultDependencyBuilderIsReturned()
    {
        Expression<Func<object, Task<object>>> expression = obj => new Task<object>(() => new object());
        
        Func<IReadArrangement, Expression<Func<object, Task<object>>>> func = arrangement => expression;

        var mock = Substitute.For<IMock<object>>();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new DependencyBuilderChainer<object>(
            arrangement,
            null
        );

        var result = sut.StartMockAsyncResultDependencyBuilder(
            func,
            mock,
            dependencyBuilder
        );

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItStartsAMockAsyncResultDependencyBuilderThenAMockAsyncResultDependencyBuilderIsReturned()
    {
        Expression<Func<object, Task<object>>> expression = obj => new Task<object>(() => new object());

        var mock = Substitute.For<IMock<object>>();

        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new DependencyBuilderChainer<object>(
            arrangement,
            null
        );

        var result = sut.StartMockAsyncResultDependencyBuilder(
            expression,
            mock,
            dependencyBuilder
        );

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItStartsANewMockDependencyBuilderThenAMockDependencyBuilderIsCreated()
    {
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewMockDependencyBuilder<object>();

        result.Should().Be(mockDependencySetupBuilder);
    }
    
    [Fact]
    public void WhenItStartsANewMockDependencyBuilderWithANameThenAMockDependencyBuilderWithANameIsCreated()
    {
        var dependencyName = "DependencyName";
        
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateMockDependencyBuilder<object>(dependencyName).Returns(mockDependencySetupBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewMockDependencyBuilder<object>(dependencyName);

        result.Should().Be(mockDependencySetupBuilder);
    }
    
    [Fact]
    public void WhenItStartsAnExistingMockDependencyBuilderThenAnExistingMockDependencyBuilderIsCreated()
    {
        var mockDependencySetupBuilder = Substitute.For<IMockDependencySetupBuilder<object, object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateExistingMockDependencyBuilder<object>().Returns(mockDependencySetupBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewExistingMockDependencyBuilder<object>();

        result.Should().Be(mockDependencySetupBuilder);
    }
    
    [Fact]
    public void WhenItStartsANewDependencyBuilderWithANameThenANewDependencyBuilderWithANameIsCreated()
    {
        var dependency = new object();
        
        var dependencyName = "DependencyName";
        
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateObjectDependencyBuilder(dependency, dependencyName).Returns(dependencyBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewObjectDependencyBuilder(
            dependency,
            dependencyName
            );

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItStartsANewExistingDependencyBuilderThenANewDependencyBuilderIsCreated()
    {
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.Create<object>().Returns(dependencyBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewExistingObjectDependencyBuilder<object>();

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItStartsANewExistingObjectDependencyBuilderWithANameThenANewDependencyBuilderWithANameIsCreated()
    {
        var dependencyName = "DependencyName";
        
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.Create<object>(dependencyName).Returns(dependencyBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewExistingObjectDependencyBuilder<object>(
            dependencyName
            );

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItStartsANewObjectDependencyBuilderThenANewObjectDependencyBuilderIsCreated()
    {
        var dependency = new object();
        
        var dependencyBuilder = Substitute.For<IDependencyBuilder<object>>();
        
        var dependencyBuilderCreator = Substitute.For<IDependencyBuilderCreator<object>>();
        dependencyBuilderCreator.CreateObjectDependencyBuilder(dependency).Returns(dependencyBuilder);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.DependencyBuilderCreator.Returns(dependencyBuilderCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartNewObjectDependencyBuilder(
            dependency
            );

        result.Should().Be(dependencyBuilder);
    }
    
    [Fact]
    public void WhenItStartsAVoidAsserterFromAnArrangementActionThenAVoidAsserterIsCreated()
    {
        Action<ISutArrangement<object>> action = arrangement => { }; 
        
        var voidAsserter = Substitute.For<IVoidAsserter<object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateVoidAsserter(action).Returns(voidAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartVoidAsserter(
            action
        );

        result.Should().Be(voidAsserter);
    }
    
    [Fact]
    public void WhenItStartsAResultAsserterThenAResultAsserterIsCreated()
    {
        Func<object, object> func = arrangement => new object(); 
        
        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateResultAsserter(func).Returns(resultAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartResultAsserter(
            func
        );

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public async Task WhenItStartsAnAsyncResultAsserterWithAnArrangementFuncThenAnAsyncResultAsserterIsCreated()
    {
        Func<ISutArrangement<object>, Task<object>> func = async arrangement => new object(); 
        
        var asyncResultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateAsyncResultAsserter(func).Returns(asyncResultAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = await sut.StartAsyncResultAsserter(
            func
        );

        result.Should().Be(asyncResultAsserter);
    }
    
    [Fact]
    public async Task WhenItStartsAnAsyncResultAsserterThenAnAsyncResultAsserterIsCreated()
    {
        Func<object, Task<object>> func = async obj => new object(); 
        
        var asyncResultAsserter = Substitute.For<IAsyncResultAsserter<object, object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateAsyncResultAsserter(func).Returns(asyncResultAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = await sut.StartAsyncResultAsserter(
            func
        );

        result.Should().Be(asyncResultAsserter);
    }
    
    [Fact]
    public void WhenItStartsAResultAsserterFromAnArrangementFuncThenAResultAsserterIsCreated()
    {
        Func<ISutArrangement<object>, object> func = arrangement => new object(); 
        
        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateResultAsserter(func).Returns(resultAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartResultAsserter(
            func
        );

        result.Should().Be(resultAsserter);
    }
    
    [Fact]
    public void WhenItStartsASutAsserterThenASutAsserterIsCreated()
    {
        var sutPropertyTargeter = Substitute.For<ISutPropertyTargeter<object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateSutAsserter().Returns(sutPropertyTargeter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartSutAsserter();

        result.Should().Be(sutPropertyTargeter);
    }
    
    [Fact]
    public void WhenItStartsAVoidAsserterThenAVoidAsserterIsCreated()
    {
        Action<object> action = obj => { };

        var voidAsserter = Substitute.For<IVoidAsserter<object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateVoidAsserter(action).Returns(voidAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartVoidAsserter(action);

        result.Should().Be(voidAsserter);
    }
    
    [Fact]
    public void WhenItStartsAResultAsserterFromAReadArrangementFuncThenAResultAsserterIsCreated()
    {
        Func<IReadArrangement, Func<object, object>> func = arrangement => obj => new object();

        var resultAsserter = Substitute.For<IResultAsserter<object, object>>();
        
        var asserterCreator = Substitute.For<IAsserterCreator<object>>();
        asserterCreator.CreateResultAsserter(func).Returns(resultAsserter);
        
        var testBuilderContainer = Substitute.For<ITestBuilderContainer<object>>();
        testBuilderContainer.AsserterCreator.Returns(asserterCreator);
        
        var sut = new DependencyBuilderChainer<object>(
            null,
            testBuilderContainer
        );

        var result = sut.StartResultAsserter(func);

        result.Should().Be(resultAsserter);
    }
}
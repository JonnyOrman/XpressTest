using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockDependencySetupBuilder
{
    [Fact]
    public void WhenItSetsUpAMockWithAnArrangementResultFuncThenItReturnsAMockResultDependencyBuilder()
    {
        Func<IReadArrangement, Expression<Func<object, object>>> func = arrangement => obj => new object();

        var mock = Substitute.For<IMock<object>>();

        var arrangement = Substitute.For<IArrangement>();
        
        var sut = new MockDependencySetupBuilder<object, object, IMock<object>>(
            mock,
            arrangement,
            null,
            null
            );

        var result = sut.ThatDoes(func);

        result.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenItSetsUpAMockWithAResultFuncThenItStartsAMockResultDependencyBuilder()
    {
        Expression<Func<object, object>> expression = obj => new object();

        var mock = Substitute.For<IMock<object>>();

        var mockResultDependencyBuilder = Substitute.For<IMockResultBuilder<object, IDependencyBuilder<object>>>();

        var chainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new MockDependencySetupBuilder<object, object, IMock<object>>(
            mock,
            null,
            null,
            chainer
        );

        chainer.StartMockResultDependencyBuilder(
            expression,
            mock,
            sut
        ).Returns(mockResultDependencyBuilder);
            
        var result = sut.ThatDoes(expression);

        result.Should().Be(mockResultDependencyBuilder);
    }
    
    [Fact]
    public void WhenItSetsUpAMockWithAnAsyncArrangementResultFuncThenItStartsAMockAsyncResultDependencyBuilder()
    {
        Expression<Func<object, Task<object>>> expression = obj => new Task<object>(() => new object());
        
        Func<IReadArrangement, Expression<Func<object, Task<object>>>> func = arrangement => expression;

        var mock = Substitute.For<IMock<object>>();

        var mockAsyncResultDependencyBuilder = Substitute.For<IMockAsyncResultDependencyBuilder<object, object>>();

        var chainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new MockDependencySetupBuilder<object, object, IMock<object>>(
            mock,
            null,
            null,
            chainer
        );

        chainer.StartMockAsyncResultDependencyBuilder(
            func,
            mock,
            sut
        ).Returns(mockAsyncResultDependencyBuilder);
            
        var result = sut.ThatDoesAsync(func);

        result.Should().Be(mockAsyncResultDependencyBuilder);
    }
    
    [Fact]
    public void WhenItSetsUpAMockWithAnAsyncResultFuncThenItStartsAMockAsyncResultDependencyBuilder()
    {
        Expression<Func<object, Task<object>>> expression = obj => new Task<object>(() => new object());
        
        var mock = Substitute.For<IMock<object>>();

        var mockAsyncResultDependencyBuilder = Substitute.For<IMockAsyncResultDependencyBuilder<object, object>>();

        var chainer = Substitute.For<IDependencyBuilderChainer<object>>();

        var sut = new MockDependencySetupBuilder<object, object, IMock<object>>(
            mock,
            null,
            null,
            chainer
        );

        chainer.StartMockAsyncResultDependencyBuilder(
            expression,
            mock,
            sut
        ).Returns(mockAsyncResultDependencyBuilder);
            
        var result = sut.ThatDoesAsync(expression);

        result.Should().Be(mockAsyncResultDependencyBuilder);
    }
}
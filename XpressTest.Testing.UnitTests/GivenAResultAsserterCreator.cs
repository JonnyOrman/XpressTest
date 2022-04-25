using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultAsserterCreator
{
    [Fact]
    public void WhenItCreatesAResultAsserterFromASutArrangementFuncThenItCreatesAResultAsserter()
    {
        Func<ISutArrangement<object>, object> func = sutArrangement => new object();
        
        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();
        
        var sut = new ResultAsserterCreator<object>(sutArrangementCreator);

        var result = sut.Create(func);

        result.Should().BeOfType<ResultAsserter<object, object>>();
    }
    
    [Fact]
    public void WhenItCreatesAResultAsserterFromAFuncThenItCreatesAResultAsserter()
    {
        Func<object, object> func = obj => new object();
        
        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();
        
        var sut = new ResultAsserterCreator<object>(sutArrangementCreator);

        var result = sut.Create(func);

        result.Should().BeOfType<ResultAsserter<object, object>>();
    }
    
    [Fact]
    public void WhenItCreatesAResultAsserterFromAReadArrangementFuncThenItCreatesAResultAsserter()
    {
        Func<IReadArrangement, object> func = readArrangement => new object();
        
        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();
        
        var sut = new ResultAsserterCreator<object>(sutArrangementCreator);

        var result = sut.Create(func);

        result.Should().BeOfType<ResultAsserter<object, object>>();
    }
    
    [Fact]
    public async Task WhenItCreatesAnAsyncResultAsserterFromASutArrangementFuncThenItCreatesAnAsyncResultAsserter()
    {
        Func<ISutArrangement<object>, Task<object>> func = async sutArrangement => new object();
        
        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();
        
        var sut = new ResultAsserterCreator<object>(sutArrangementCreator);

        var result = await sut.CreateAsync(func);

        result.Should().BeOfType<AsyncResultAsserter<object, object>>();
    }
    
    [Fact]
    public async Task WhenItCreatesAnAsyncResultAsserterFromAFuncThenItCreatesAnAsyncResultAsserter()
    {
        Func<object, Task<object>> func = async obj => new object();
        
        var sutArrangementCreator = Substitute.For<ISutArrangementCreator<object>>();
        
        var sut = new ResultAsserterCreator<object>(sutArrangementCreator);

        var result = await sut.CreateAsync(func);

        result.Should().BeOfType<AsyncResultAsserter<object, object>>();
    }
}
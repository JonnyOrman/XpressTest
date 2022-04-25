using System;
using FluentAssertions;
using NSubstitute;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;
using Xunit.Sdk;

namespace XpressTest.Testing.UnitTests;

public class GivenAResultAsserter
{
    [Fact]
    public void WhenItAssertsAnAssertionActionThenItInvokesTheActionOnAnAssertion()
    {
        var actionInvoked = false;

        Action<IResultAssertion<object>> action = resultAssertion =>
        {
            actionInvoked = true;
        };
        
        var testResult = new object();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        
        var sut = new ResultAsserter<object, object>(
            testResult,
            sutArrangement,
            null,
            null,
            null
            );

        sut.Then(action);

        actionInvoked.Should().BeTrue();
    }
    
    [Fact]
    public void WhenItVerifiesAMockThenItCreatesAResultMockVerifier()
    {
        var mock = Substitute.For<IMock<object>>();

        var resultMockVerifier = Substitute.For<IResultMockVerifier<object, object, object>>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.GetTheMock<object>().Returns(mock);
        
        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();
        
        var sut = new ResultAsserter<object, object>(
            null,
            sutArrangement,
            null,
            resultMockVerifierCreator,
            null
        );

        resultMockVerifierCreator.Create(mock, sut).Returns(resultMockVerifier);
            
        var result = sut.ThenThe<object>();

        result.Should().Be(resultMockVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesANamedMockThenItCreatesANamedResultMockVerifier()
    {
        var mockName = "MockName";
        
        var mock = Substitute.For<IMock<object>>();

        var resultMockVerifier = Substitute.For<IResultMockVerifier<object, object, object>>();

        var sutArrangement = Substitute.For<ISutArrangement<object>>();
        sutArrangement.GetTheMock<object>(mockName).Returns(mock);
        
        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();
        
        var sut = new ResultAsserter<object, object>(
            null,
            sutArrangement,
            null,
            resultMockVerifierCreator,
            null
        );

        resultMockVerifierCreator.Create(mock, sut).Returns(resultMockVerifier);
            
        var result = sut.ThenThe<object>(mockName);

        result.Should().Be(resultMockVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesAMoqMockThenItCreatesAResultMockVerifier()
    {
        var moqMock = new Moq.Mock<object>();

        var resultMockVerifier = Substitute.For<IResultMockVerifier<object, object, object>>();

        var resultMockVerifierCreator = Substitute.For<IResultMockVerifierCreator<object, object>>();
        
        var sut = new ResultAsserter<object, object>(
            null,
            null,
            null,
            resultMockVerifierCreator,
            null
        );

        resultMockVerifierCreator.Create(Arg.Is<Mock<object>>(mock => mock.MoqMock == moqMock), sut).Returns(resultMockVerifier);
            
        var result = sut.Then(moqMock);

        result.Should().Be(resultMockVerifier);
    }
    
    [Fact]
    public void WhenItVerifiesANullResultIsNullThenItAssertsThatTheResultIsNull()
    {
        object obj = null;
        
        var sut = new ResultAsserter<object, object>(
            obj,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBeNull());

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenItVerifiesANotNullResultIsNullThenItAssertsThatTheResultIsNotNull()
    {
        var obj = new object();
        
        var sut = new ResultAsserter<object, object>(
            obj,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBeNull());

        exception.Should().BeOfType<NullException>();
    }
    
    [Fact]
    public void WhenItVerifiesAResultPropertyThenItVerifiesTheResultProperty()
    {
        Func<object, object> func = obj => new object();

        var resultPropertyAsserter = Substitute.For<IResultPropertyAsserter<object, object, object>>();
        
        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();
        resultPropertyTargeter.ThenTheResult(func).Returns(resultPropertyAsserter);
        
        var sut = new ResultAsserter<object, object>(
            null,
            null,
            resultPropertyTargeter,
            null,
            null
        );

        var result = sut.ThenTheResult(func);

        result.Should().Be(resultPropertyAsserter);
    }
    
    [Fact]
    public void WhenItAssertsTheResultThenItAssertsTheResult()
    {
        var result = new object();
        
        var resultPropertyTargeter = Substitute.For<IResultPropertyTargeter<object, object>>();
        
        var sut = new ResultAsserter<object, object>(
            null,
            null,
            resultPropertyTargeter,
            null,
            null
        );

        sut.ThenTheResultShouldBe(result);

        resultPropertyTargeter.Received(1).ThenTheResultShouldBe(result);
    }
    
    [Fact]
    public void WhenItAssertsTheResultFromTheArrangementThenItAssertsTheResult()
    {
        var testResult = new object();

        Func<ISutArrangement<object>, object> func = arrangement => testResult;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new ResultAsserter<object, object>(
            testResult,
            sutArrangement,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBe(func));

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenItAssertsTheResultIsNotFromTheArrangementThenItAssertsTheResult()
    {
        var testResult = new object();

        var arrangementResult = new object();

        Func<ISutArrangement<object>, object> func = arrangement => arrangementResult;

        var sutArrangement = Substitute.For<ISutArrangement<object>>();

        var sut = new ResultAsserter<object, object>(
            testResult,
            sutArrangement,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBe(func));

        exception.Should().BeOfType<EqualException>();
    }
    
    [Fact]
    public void WhenItAssertsTheResultIsItsTypeThenItAssertsTheTypeIsExpected()
    {
        var testResult = new object();

        var sut = new ResultAsserter<object, object>(
            testResult,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBeA<object>());

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenItAssertsTheResultIsNotItsTypeThenItAssertsTheTypeIsNotExpected()
    {
        var testResult = new TestObject();

        var sut = new ResultAsserter<object, object>(
            testResult,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldBeA<object>());

        exception.Should().BeOfType<IsTypeException>();
    }
    
    [Fact]
    public void WhenItAssertsTheResultIsNotThenItAssertsTheTypeIsNotNull()
    {
        var testResult = new object();

        var sut = new ResultAsserter<object, object>(
            testResult,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldNotBeNull());

        exception.Should().BeNull();
    }
    
    [Fact]
    public void WhenItAssertsANullResultIsNotThenItAssertsTheTypeIsNull()
    {
        object testResult = null;

        var sut = new ResultAsserter<object, object>(
            testResult,
            null,
            null,
            null,
            null
        );

        var exception = Record.Exception(() => sut.ThenTheResultShouldNotBeNull());

        exception.Should().BeOfType<NotNullException>();
    }
    
    [Fact]
    public void WhenItAssertsAnExceptionIsThrownThenItAssertsTheExceptionIsThrown()
    {
        var exceptionAsserter = Substitute.For<IExceptionAsserter>();

        var sut = new ResultAsserter<object, object>(
            null,
            null,
            null,
            null,
            exceptionAsserter
        );

        sut.ThenItShouldThrow<Exception>();
        
        exceptionAsserter.Received(1).ThenItShouldThrow<Exception>();
    }
}
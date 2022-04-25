using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NSubstitute;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockResultCallCountVerifier
{
    [Fact]
    public void WhenItVerifiesThatTheExpectedNumberOfCallsWereMadeThenItDoesNotThrow()
    {
        var moqMock = new Moq.Mock<ITestObject>();
        
        var mock = Substitute.For<IMock<ITestObject>>();
        mock.MoqMock.Returns(moqMock);

        Expression<Func<ITestObject, int>> expression = testObject => testObject.Execute();
        
        var sut = new MockResultCallCountVerifier<ITestObject, int>(
            mock,
            expression
            );

        moqMock.Object.Execute();
        
        sut.Verify(1);
    }
    
    [Fact]
    public void WhenItVerifiesThatTheExpectedNumberOfCallsWasNotMadeThenItThrows()
    {
        var moqMock = new Moq.Mock<ITestObject>();
        
        var mock = Substitute.For<IMock<ITestObject>>();
        mock.MoqMock.Returns(moqMock);

        Expression<Func<ITestObject, int>> expression = testObject => testObject.Execute();
        
        var sut = new MockResultCallCountVerifier<ITestObject, int>(
            mock,
            expression
        );

        moqMock.Object.Execute();
        
        Assert.Throws<MockException>(() => sut.Verify(2));
    }
}
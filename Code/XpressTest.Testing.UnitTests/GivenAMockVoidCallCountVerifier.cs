using Moq;
using NSubstitute;
using System;
using System.Linq.Expressions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockVoidCallCountVerifier
{
    [Fact]
    public void WhenItVerifiesThatTheExpectedNumberOfCallsWereMadeThenItDoesNotThrow()
    {
        var moqMock = new Moq.Mock<ITestObject>();

        var mock = Substitute.For<IMock<ITestObject>>();
        mock.MoqMock.Returns(moqMock);

        Expression<Action<ITestObject>> expression = testObject => testObject.ExecuteVoid();

        var sut = new MockVoidCallCountVerifier<ITestObject>(
            mock,
            expression
        );

        moqMock.Object.ExecuteVoid();

        sut.Verify(1);
    }

    [Fact]
    public void WhenItVerifiesThatTheExpectedNumberOfCallsWasNotMadeThenItThrows()
    {
        var moqMock = new Moq.Mock<ITestObject>();

        var mock = Substitute.For<IMock<ITestObject>>();
        mock.MoqMock.Returns(moqMock);

        Expression<Action<ITestObject>> expression = testObject => testObject.ExecuteVoid();

        var sut = new MockVoidCallCountVerifier<ITestObject>(
            mock,
            expression
        );

        moqMock.Object.ExecuteVoid();

        Assert.Throws<MockException>(() => sut.Verify(2));
    }
}
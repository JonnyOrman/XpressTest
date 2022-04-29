using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockResultDependencyBuilder
{
    [Fact]
    public void WhenItSetsUpTheMocksResultThenItReturnsTheBuilder()
    {
        var setupResult = 123;

        Expression<Func<ITestObject, int>> expression = testObject => testObject.Execute();

        var moqMock = new Moq.Mock<ITestObject>();

        var dependencyMock = Substitute.For<IMock<ITestObject>>();
        dependencyMock.MoqMock.Returns(moqMock);

        var mockDependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var sut = new MockResultBuilder<ITestObject, int, object>(
            expression,
            dependencyMock,
            mockDependencyBuilder,
            null
            );

        var result = sut.AndReturns(setupResult);

        var mockResult = moqMock.Object.Execute();
        mockResult.Should().Be(123);

        result.Should().Be(mockDependencyBuilder);
    }

    [Fact]
    public void WhenItSetsUpTheMocksResultFromTheArrangementThenItReturnsTheBuilder()
    {
        Func<IReadArrangement, int> func = arrangement => 123;

        Expression<Func<ITestObject, int>> expression = testObject => testObject.Execute();

        var moqMock = new Moq.Mock<ITestObject>();

        var dependencyMock = Substitute.For<IMock<ITestObject>>();
        dependencyMock.MoqMock.Returns(moqMock);

        var mockDependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var sut = new MockResultBuilder<ITestObject, int, object>(
            expression,
            dependencyMock,
            mockDependencyBuilder,
            null
        );

        var result = sut.AndReturns(func);

        var mockResult = moqMock.Object.Execute();
        mockResult.Should().Be(123);

        result.Should().Be(mockDependencyBuilder);
    }

    [Fact]
    public void WhenItSetsUpTheMockToReturnAMockThenItReturnsTheBuilder()
    {
        var obj = new object();

        Expression<Func<ITestObject, object>> expression = testObject => testObject.ReturnObject();

        var moqMock = new Moq.Mock<ITestObject>();

        var dependencyMock = Substitute.For<IMock<ITestObject>>();
        dependencyMock.MoqMock.Returns(moqMock);

        var mockDependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();
        arrangement.GetTheMockObject<object>().Returns(obj);

        var sut = new MockResultBuilder<ITestObject, object, object>(
            expression,
            dependencyMock,
            mockDependencyBuilder,
            arrangement
        );

        var result = sut.AndReturnsTheMock<object>();

        var mockResult = moqMock.Object.ReturnObject();
        mockResult.Should().Be(obj);

        result.Should().Be(mockDependencyBuilder);
    }
}
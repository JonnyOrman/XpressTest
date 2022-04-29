using FluentAssertions;
using NSubstitute;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpressTest.Testing.UnitTests.TestClasses;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAMockAsyncResultDependencyBuilder
{
    [Fact]
    public async Task WhenItsResultIsSetupThenTheMoqMockExpressionResultIsSetupAndTheMockDependencyBuilderIsReturned()
    {
        var setupResult = new object();

        Expression<Func<ITestAsyncInterface, Task<object>>> expression = testAsyncInterface => testAsyncInterface.GetAsync();

        var moqMock = new Moq.Mock<ITestAsyncInterface>();

        var mock = Substitute.For<IMock<ITestAsyncInterface>>();
        mock.MoqMock.Returns(moqMock);

        var mockDependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new MockAsyncResultDependencyBuilder<object, ITestAsyncInterface, object>(
            expression,
            mock,
            mockDependencyBuilder,
            arrangement
            );

        var result = sut.AndReturns(setupResult);

        var setup = moqMock.Setups.First();
        setup.Mock.Should().Be(moqMock);
        setup.OriginalExpression.Should().Be(expression);

        var retrievedSetupResult = await moqMock.Object.GetAsync();
        retrievedSetupResult.Should().Be(setupResult);

        result.Should().Be(mockDependencyBuilder);
    }

    [Fact]
    public async Task WhenItsResultIsSetupFromTheArrangementThenTheMoqMockExpressionResultIsSetupAndTheMockDependencyBuilderIsReturned()
    {
        var setupResult = new object();

        Func<IReadArrangement, object> setupResultFunc = arrangement => setupResult;

        Expression<Func<ITestAsyncInterface, Task<object>>> expression = testAsyncInterface => testAsyncInterface.GetAsync();

        var moqMock = new Moq.Mock<ITestAsyncInterface>();

        var mock = Substitute.For<IMock<ITestAsyncInterface>>();
        mock.MoqMock.Returns(moqMock);

        var mockDependencyBuilder = Substitute.For<IDependencyBuilder<object>>();

        var arrangement = Substitute.For<IArrangement>();

        var sut = new MockAsyncResultDependencyBuilder<object, ITestAsyncInterface, object>(
            expression,
            mock,
            mockDependencyBuilder,
            arrangement
        );

        var result = sut.AndReturns(setupResultFunc);

        var setup = moqMock.Setups.First();
        setup.Mock.Should().Be(moqMock);
        setup.OriginalExpression.Should().Be(expression);

        var retrievedSetupResult = await moqMock.Object.GetAsync();
        retrievedSetupResult.Should().Be(setupResult);

        result.Should().Be(mockDependencyBuilder);
    }
}
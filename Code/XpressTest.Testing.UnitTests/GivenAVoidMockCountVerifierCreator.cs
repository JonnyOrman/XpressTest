using FluentAssertions;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace XpressTest.Testing.UnitTests;

public class GivenAVoidMockCountVerifierCreator
{
    [Fact]
    public void WhenItCreatesAnActionMockCountVerifierThenItReturnsAMockCountVerifier()
    {
        Expression<Action<object>> expression = obj => new object();

        var voidMockCallVerifierCreator = Substitute.For<IVoidMockCallVerifierCreator<object, object>>();

        var sut = new VoidMockCountVerifierCreator<object, object>(
            voidMockCallVerifierCreator
            );

        var result = sut.Create(expression);

        result.Should().BeOfType<MockCountVerifier<object>>();
    }
}
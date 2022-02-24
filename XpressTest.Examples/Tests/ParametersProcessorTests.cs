using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorTests
{
    [Fact]
    public void ProcessValidParameters() =>
        GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty))
            .AndGiven(new Entity(1, string.Empty))
            .WithA<IValidator>()
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>()))
                .AndReturns(true)
            .WithA<ICreator>()
                .ThatDoes<Entity>(arrangement => creator => creator.Create(arrangement.GetObject<EntityParameters>()))
                .AndReturns(arrangement => arrangement.GetObject<Entity>())
            .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>()))
            .Then(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(validator => validator.IsValid(assertion.GetObject<EntityParameters>()),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(assertion.GetObject<EntityParameters>()),
                        Times.Once);
                Assert.Equal(assertion.GetObject<Entity>(), assertion.Result);
            })
            .Test();

    [Fact]
    public void ProcessInvalidParameters() =>
        GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty))
            .WithA<IValidator>()                                                                                                                                                                            
                .ThatDoes<bool>(arrangement => validator => validator.IsValid(arrangement.GetObject<EntityParameters>()))
                .AndReturns(false)
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>()))
            .Then(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(
                        validator => validator.IsValid(assertion.GetObject<EntityParameters>()),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(It.IsAny<EntityParameters>()),
                        Times.Never);
                Assert.Null(assertion.Result);
            })
            .Test();
}
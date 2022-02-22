using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorTests
{
    [Fact]
    public void ProcessValidParameters() =>
        GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty), "parameters")
            .AndGiven(new Entity(1, string.Empty), "entity")
            .WithA<IValidator>()
            .ThatDoes(arrangement =>
                new MockSetup<IValidator, bool>(
                    validator => validator.IsValid(arrangement.GetObject<EntityParameters>("parameters")),
                    true))
            .WithA<ICreator>()
            .ThatDoes(arrangement =>
                new MockSetup<ICreator, Entity>(
                    creator => creator.Create(arrangement.GetObject<EntityParameters>("parameters")),
                    arrangement.Objects.Get<Entity>("entity")
                ))
            .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(validator => validator.IsValid(assertion.GetObject<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(assertion.GetObject<EntityParameters>("parameters")),
                        Times.Once);
                Assert.Equal(assertion.GetObject<Entity>("entity"), assertion.Result);
            })
            .Test();

    [Fact]
    public void ProcessInvalidParameters() =>
        GivenA<ParametersProcessor>
            .AndGiven(new EntityParameters(string.Empty), "parameters")
            .WithA<IValidator>()
            .ThatDoes(arrangement => new MockSetup<IValidator, bool>(
                validator => validator.IsValid(arrangement.GetObject<EntityParameters>("parameters")),
                false))
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.GetObject<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(
                        validator => validator.IsValid(assertion.GetObject<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(It.IsAny<EntityParameters>()),
                        Times.Never);
                Assert.Null(assertion.Result);
            })
            .Test();
}
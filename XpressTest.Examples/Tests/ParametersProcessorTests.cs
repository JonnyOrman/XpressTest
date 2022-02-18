using Moq;
using XpressTest.Examples.Src;
using Xunit;

namespace XpressTest.Examples.Tests;

public class ParametersProcessorTests
{
    [Fact]
    public void ProcessValidParameters() =>
        GivenA<ParametersProcessor>
            .And(new EntityParameters(string.Empty), "parameters")
            .And(new Entity(1, string.Empty), "entity")
            .WithA<IValidator>()
            .That(arrangement =>
                new MockSetup<IValidator, bool>(
                    validator => validator.IsValid(arrangement.Objects.Get<EntityParameters>("parameters")),
                    true))
            .WithA<ICreator>()
            .That(arrangement =>
                new MockSetup<ICreator, Entity>(
                    creator => creator.Create(arrangement.Objects.Get<EntityParameters>("parameters")),
                    arrangement.Objects.Get<Entity>("entity")
                ))
            .WhenIt(action => action.Sut.Process(action.Objects.Get<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(validator => validator.IsValid(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                Assert.Equal(assertion.Objects.Get<Entity>("entity"), assertion.Result);
            })
            .Test();

    [Fact]
    public void ProcessInvalidParameters() =>
        GivenA<ParametersProcessor>
            .And(new EntityParameters(string.Empty), "parameters")
            .WithA<IValidator>()
            .That(arrangement => new MockSetup<IValidator, bool>(
                validator => validator.IsValid(arrangement.Objects.Get<EntityParameters>("parameters")),
                false))
            .WithA<ICreator>()
            .WhenIt(action => action.Sut.Process(action.Objects.Get<EntityParameters>("parameters")))
            .ThenItShould(assertion =>
            {
                assertion.Dependencies.GetMock<IValidator>()
                    .Verify(
                        validator => validator.IsValid(assertion.Objects.Get<EntityParameters>("parameters")),
                        Times.Once);
                assertion.Dependencies.GetMock<ICreator>()
                    .Verify(
                        creator => creator.Create(It.IsAny<EntityParameters>()),
                        Times.Never);
                Assert.Null(assertion.Result);
            })
            .Test();
}
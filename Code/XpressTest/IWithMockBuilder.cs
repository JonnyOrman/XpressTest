namespace XpressTest;

public interface IWithMockBuilder<TSut>
{
    IMockDependencySetupBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;
}
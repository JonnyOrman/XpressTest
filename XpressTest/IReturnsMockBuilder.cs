namespace XpressTest;

public interface IReturnsMockBuilder<TResult, TBuilder>
{
    TBuilder AndReturnsTheMock<TMock>()
        where TMock : class, TResult;
}
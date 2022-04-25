namespace XpressTest;

public interface IReturnsMockResultBuilder<TResult, TBuilder>
{
    TBuilder AndReturns(
        TResult expectedResult
    );
}
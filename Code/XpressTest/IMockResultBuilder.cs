namespace XpressTest;

public interface IMockResultBuilder<TResult, TBuilder>
:
    IReturnsMockBuilder<TResult, TBuilder>,
    IReturnsMockResultBuilder<TResult, TBuilder>,
    IReturnsArrangementResultBuilder<TResult, TBuilder>
{
}
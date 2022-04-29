namespace XpressTest;

public interface IReturnsArrangementResultBuilder<TResult, TBuilder>
{
    TBuilder AndReturns(
        Func<IReadArrangement, TResult> resultFunc
    );
}
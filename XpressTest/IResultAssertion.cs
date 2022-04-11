namespace XpressTest;

public interface IResultAssertion<TResult>
    :
        IReadArrangement
{
    TResult Result { get; }
}
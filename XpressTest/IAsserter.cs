namespace XpressTest;

public interface IAsserter<TAssertion>
{
    ITester Then(TAssertion assertion);
}

public interface IAsserter<TAssertion, TResult> : IAsserter<TAssertion>, IResultPropertyTargeter<TResult>
{

}
namespace XpressTest;

public interface IAssertion<TSut, TResult> : IAssertion<TSut>
{
    TResult Result { get; }
}

public interface IAssertion<TSut> : IArrangement
{
    IAction<TSut> Action { get; }
}
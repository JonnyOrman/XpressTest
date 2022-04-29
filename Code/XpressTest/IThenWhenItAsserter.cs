namespace XpressTest;

public interface IThenWhenItAsserter<TSut>
{
    IVoidAsserter<TSut> ThenWhenIt(
        Action<ISutArrangement<TSut>> action
    );

    IResultAsserter<TSut, TActionResult> ThenWhenIt<TActionResult>(
        Func<TSut, TActionResult> func
    );
}
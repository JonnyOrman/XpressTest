namespace XpressTest;

public interface IThenWhenItAsserter<TSut>
{
    IVoidAsserter<TSut> ThenWhenIt(
        Action<TSut> action
    );
    
    IVoidAsserter<TSut> ThenWhenIt(
        Action<ISutArrangement<TSut>> action
    );

    IResultAsserter<TSut, TActionResult> ThenWhenIt<TActionResult>(
        Func<TSut, TActionResult> func
    );
    
    IResultAsserter<TSut, TActionResult> ThenWhenIt<TActionResult>(
        Func<ISutArrangement<TSut>, TActionResult> func
    );
}
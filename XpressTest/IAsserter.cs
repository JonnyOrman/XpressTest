namespace XpressTest;

public interface IAsserter<TAction>
:
    IThenActionAsserter<TAction>,
    IExceptionAsserter
{
    
    
}
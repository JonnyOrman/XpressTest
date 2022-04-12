namespace XpressTest;

public interface IThenActionAsserter<TAction>
{
    void Then(Action<TAction> assertion);
}
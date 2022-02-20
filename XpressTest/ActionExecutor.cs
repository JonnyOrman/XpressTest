namespace XpressTest;

public abstract class ActionExecutor<TAction>
{
    protected readonly TAction _action;

    protected ActionExecutor(
        TAction action
        )
    {
        _action = action;
    }
}

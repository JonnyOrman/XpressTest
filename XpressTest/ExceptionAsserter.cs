namespace XpressTest;

public class ExceptionAsserter : IExceptionAsserter
{
    private readonly Action _action;

    public ExceptionAsserter(Action action)
    {
        _action = action;
    }

    public void Assert<TException>()
        where TException : Exception
    {
        try
        {
            _action.Invoke();
        }
        catch (Exception exception)
        {
            if (exception.GetType() != typeof(TException))
            {
                throw exception;
            }
        }
    }
}

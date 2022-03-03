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
        var exceptionThrown = false;
        
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
            else
            {
                exceptionThrown = true;
            }
        }

        if (!exceptionThrown)
        {
            throw new Exception("Expected exception not thrown");
        }
    }
}

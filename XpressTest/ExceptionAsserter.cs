namespace XpressTest;

public class 
    ExceptionAsserter : IExceptionAsserter
{
    private readonly Action _action;

    public ExceptionAsserter(Action action)
    {
        _action = action;
    }

    public void ThenItShouldThrow<TException>()
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
            throw new ExceptionNotThrownException($"Expected exception of type {typeof(TException).Name} but no exception was thrown");
        }
    }
}

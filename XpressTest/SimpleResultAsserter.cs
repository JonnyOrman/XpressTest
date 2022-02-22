namespace XpressTest;

public class SimpleResultAsserter<TResult> : ISimpleAsserter
{
    private readonly IResultProvider<TResult> _resultProvider;

    public SimpleResultAsserter(
        IResultProvider<TResult> resultProvider
        )
    {
        _resultProvider = resultProvider;
    }
    
    public void ThenItShouldThrow<TException>()
        where TException : Exception
    {
        try
        {
            _resultProvider.Get();
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

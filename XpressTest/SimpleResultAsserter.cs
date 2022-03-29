namespace XpressTest;

public class SimpleResultAsserter<TSut, TResult> : ISimpleResultAsserter<TResult>
{
    private readonly TSut _sut;
    private readonly IArrangement _arrangement;
    private readonly Func<TResult> _action;

    public SimpleResultAsserter(
        TSut sut,
        IArrangement arrangement,
        Func<TResult> action
        )
    {
        _sut = sut;
        _arrangement = arrangement;
        _action = action;
    }

    public void Then(System.Action<IAssertion<TResult>> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);

        var result = _action.Invoke();
        
        var assertion = new Assertion<TSut, TResult>(
            result,
            sutAction);

        action.Invoke(assertion);
    }

    public void ThenItShouldThrow<TException>() where TException : Exception
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
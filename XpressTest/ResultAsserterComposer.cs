namespace XpressTest;

public class ResultAsserterComposer<TSut>
    :
        IResultAsserterComposer<TSut>
    where TSut : class
{
    private readonly IArrangementSutComposer<TSut> _sutComposer;

    public ResultAsserterComposer(
        IArrangementSutComposer<TSut> sutComposer
        )
    {
        _sutComposer = sutComposer;
    }
    
    public IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IAction<TSut>, TResult> func, 
        IArrangement arrangement
        )
    {
        var sut = _sutComposer.Compose(
            arrangement
            );
        
        var action = new Action<TSut>(
            sut,
            arrangement
        );
        
        var result = func.Invoke(action);
        
        var resultPropertyTargeter = new ResultPropertyTargeter<TResult>(
            result,
            arrangement
            );
        
        var mockCounterVerifierCreatorComposer =
            new MockCounterVerifierCreatorComposer<IResultAsserter<TSut, TResult>>(
                arrangement
                );
        
        var resultMockVerifierCreator = new ResultMockVerifierCreator<TSut, TResult>(
            mockCounterVerifierCreatorComposer
            );
        
        return new ResultAsserter<TSut, TResult>(
            result,
            arrangement,
            resultPropertyTargeter,
            resultMockVerifierCreator,
            sut
        );
    }
}
namespace XpressTest;

public class VoidAsserterCreator<TSut>
    :
        IVoidAsserterCreator<TSut>
where TSut : class
{
    private readonly ISutArrangementCreator<TSut> _sutArrangementCreator;

    public VoidAsserterCreator(
        ISutArrangementCreator<TSut> sutArrangementCreator
        )
    {
        _sutArrangementCreator = sutArrangementCreator;
    }
    
    public IVoidAsserter<TSut> Create(Action<TSut> action)
    {
        var sutArrangement = _sutArrangementCreator.Create();

        action.Invoke(sutArrangement.Sut);

        Action exceptionAction = () => action.Invoke(sutArrangement.Sut);

        return Create(
            sutArrangement,
            exceptionAction
        );
    }

    public IVoidAsserter<TSut> Create(Action<ISutArrangement<TSut>> action)
    {
        var sutArrangement = _sutArrangementCreator.Create();

        action.Invoke(sutArrangement);

        var exceptionAction = () => action.Invoke(sutArrangement);

        return Create(
            sutArrangement,
            exceptionAction
        );
    }

    private IVoidAsserter<TSut> Create(
        ISutArrangement<TSut> sutArrangement,
        Action exceptionAction
        )
    {
        var mockCountVerifierCreatorComposer = new MockCountVerifierCreatorComposer<TSut, IVoidAsserter<TSut>>(
            sutArrangement
        );
        
        var voidMockVerifierCreator = new VoidMockVerifierCreator<TSut>(
            mockCountVerifierCreatorComposer
        );

        var exceptionAsserter = new ExceptionAsserter(
            exceptionAction
        );
        
        return new VoidAsserter<TSut>(
            sutArrangement,
            voidMockVerifierCreator,
            exceptionAsserter
        );
    }
}
namespace XpressTest;

public class VoidAsserter<TSut> : IVoidAsserter<TSut>
    where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IVoidMockVerifierCreator<TSut> _voidMockVerifierCreator;
    private readonly TSut _sut;

    public VoidAsserter(
        IArrangement arrangement,
        IVoidMockVerifierCreator<TSut> voidMockVerifierCreator,
        TSut sut
        )
    {
        _arrangement = arrangement;
        _voidMockVerifierCreator = voidMockVerifierCreator;
        _sut = sut;
    }
    
    public IVoidMockVerifier<TSut, TMock> Then<TMock>()
        where TMock : class
    {
        return _voidMockVerifierCreator.Create<TMock>(
            this
            );
    }

    public void Then(System.Action<IAssertion<TSut>> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);
        
        var assertion = new VoidAssertion<TSut>(
            sutAction
            );

        action.Invoke(assertion);
    }
}
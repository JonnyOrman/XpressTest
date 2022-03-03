namespace XpressTest;

public class VoidAsserter<TSut> : IVoidAsserter<TSut>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;

    public VoidAsserter(
        ISutComposer<TSut> sutComposer
        )
    {
        _sutComposer = sutComposer;
    }
    
    public IVoidMockVerifier<TSut, TMock> Then<TMock>()
        where TMock : class
    {
        var mock = _sutComposer.Arrangement.GetMock<TMock>();
        
        return new VoidMockVerifier<TSut, TMock>(
            mock,
            _sutComposer
        );
    }

    public void Then(System.Action<IAssertion<TSut>> action)
    {
        var sutComposer = new SutComposer<TSut>(
            _sutComposer.Arrangement
        );
        
        var sut = sutComposer.Compose();

        var sutAction = new Action<TSut>(sut, _sutComposer.Arrangement);
        
        var assertion = new VoidAssertion<TSut>(
            sutAction
            );

        action.Invoke(assertion);
    }
}
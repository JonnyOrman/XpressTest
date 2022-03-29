using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockVerifier<TSut, TMock>
    :
        IVoidMockVerifier<TSut, TMock>
    where TSut : class
    where TMock : class
{
    private readonly IMockCounterVerifierCreator<TMock, IVoidAsserter<TSut>> _mockCounterVerifierCreator;
    private readonly IVoidAsserter<TSut> _asserter;

    public VoidMockVerifier(
        IMockCounterVerifierCreator<TMock, IVoidAsserter<TSut>> mockCounterVerifierCreator,
        IVoidAsserter<TSut> asserter
        )
    {
        _mockCounterVerifierCreator = mockCounterVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCounterVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }

    public IMockCounterVerifier<IVoidAsserter<TSut>> Should(
        Func<IArrangement, Expression<System.Action<TMock>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCounterVerifier<IVoidAsserter<TSut>> Should(
        Expression<System.Action<TMock>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }
}
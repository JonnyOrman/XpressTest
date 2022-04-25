using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockVerifier<TSut, TMock>
    :
        IVoidMockVerifier<TSut, TMock>
    where TSut : class
    where TMock : class
{
    private readonly IMockCountVerifierCreator<TMock, IVoidAsserter<TSut>> _mockCountVerifierCreator;
    private readonly IVoidAsserter<TSut> _asserter;

    public VoidMockVerifier(
        IMockCountVerifierCreator<TMock, IVoidAsserter<TSut>> mockCountVerifierCreator,
        IVoidAsserter<TSut> asserter
        )
    {
        _mockCountVerifierCreator = mockCountVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCountVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _mockCountVerifierCreator.Create(
            expression
        );
    }

    public IMockCountVerifier<IVoidAsserter<TSut>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        )
    {
        return _mockCountVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCountVerifier<IVoidAsserter<TSut>> Should(
        Expression<Action<TMock>> expression
        )
    {
        return _mockCountVerifierCreator.Create(
            expression
        );
    }
}
using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementVoidMockCallVerifierCreator<TMock, TAsserter>
    :
        IArrangementVoidMockCallVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IMockCallCountVerifierCreator<TMock> _mockCallCountVerifierCreator;
    private readonly IReadArrangement _arrangement;

    public ArrangementVoidMockCallVerifierCreator(
        IMockCallCountVerifierCreator<TMock> mockCallCountVerifierCreator,
        IReadArrangement arrangement
        )
    {
        _mockCallCountVerifierCreator = mockCallCountVerifierCreator;
        _arrangement = arrangement;
    }
    
    public IMockCallVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
        )
    {
        var mockCallCountVerifier = _mockCallCountVerifierCreator.Create(
            func.Invoke(_arrangement)
        );
        
        return new MockCallVerifier<TAsserter>(
            mockCallCountVerifier,
            asserter
        );
    }
}
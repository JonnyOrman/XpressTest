using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementResultMockCallVerifierCreator<TMock, TAsserter>
    :
        IArrangementResultMockCallVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IMockCallCountVerifierCreator<TMock> _mockCallCountVerifierCreator;
    private readonly IArrangement _arrangement;
    
    public ArrangementResultMockCallVerifierCreator(
        IMockCallCountVerifierCreator<TMock> mockCallCountVerifierCreator,
        IArrangement arrangement
        )
    {
        _mockCallCountVerifierCreator = mockCallCountVerifierCreator;
        _arrangement = arrangement;
    }
    
    public IMockCallVerifier<TAsserter> Create<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
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
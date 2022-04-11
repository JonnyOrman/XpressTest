using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementResultMockCallVerifierCreator<TMock, TAsserter>
    :
        IArrangementResultMockCallVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IMockCallCountVerifierCreator<TMock> _mockCallCountVerifierCreator;
    private readonly IReadArrangement _readArrangement;
    
    public ArrangementResultMockCallVerifierCreator(
        IMockCallCountVerifierCreator<TMock> mockCallCountVerifierCreator,
        IReadArrangement readArrangement
        )
    {
        _mockCallCountVerifierCreator = mockCallCountVerifierCreator;
        _readArrangement = readArrangement;
    }
    
    public IMockCallVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        )
    {
        var mockCallCountVerifier = _mockCallCountVerifierCreator.Create(
            func.Invoke(_readArrangement)
        );
        
        return new MockCallVerifier<TAsserter>(
            mockCallCountVerifier,
            asserter
        );
    }
}
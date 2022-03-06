using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockCallVerifierCreator<TMock, TAsserter>
    : 
        IResultMockCallVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IMockCallCountVerifierCreator<TMock> _mockCallCountVerifierCreator;
    private readonly TAsserter _asserter;

    public ResultMockCallVerifierCreator(
        IMockCallCountVerifierCreator<TMock> mockCallCountVerifierCreator,
        TAsserter asserter
        )
    {
        _mockCallCountVerifierCreator = mockCallCountVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCallVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        var mockCallCountVerifier = _mockCallCountVerifierCreator.Create(
            expression
            );
        
        return new MockCallVerifier<TAsserter>(
            mockCallCountVerifier,
            _asserter
        );
    }
}
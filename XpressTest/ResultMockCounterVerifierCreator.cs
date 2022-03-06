using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockCounterVerifierCreator<TMock, TAsserter>
    :
        IResultMockCounterVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    private readonly IResultMockCallVerifierCreator<TMock, TAsserter> _resultMockCallVerifierCreator;

    public ResultMockCounterVerifierCreator(
        IResultMockCallVerifierCreator<TMock, TAsserter> resultMockCallVerifierCreator
        )
    {
        _resultMockCallVerifierCreator = resultMockCallVerifierCreator;
    }
    
    public IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        var mockCallVerifier = _resultMockCallVerifierCreator.Create(
            expression
        );
        
        return new MockCounterVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}
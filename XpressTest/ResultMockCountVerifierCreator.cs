using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockCountVerifierCreator<TMock, TAsserter>
    :
        IResultMockCountVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    private readonly IResultMockCallVerifierCreator<TMock, TAsserter> _resultMockCallVerifierCreator;

    public ResultMockCountVerifierCreator(
        IResultMockCallVerifierCreator<TMock, TAsserter> resultMockCallVerifierCreator
        )
    {
        _resultMockCallVerifierCreator = resultMockCallVerifierCreator;
    }
    
    public IMockCountVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        var mockCallVerifier = _resultMockCallVerifierCreator.Create(
            expression
        );
        
        return new MockCountVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}
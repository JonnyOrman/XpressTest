using System.Linq.Expressions;

namespace XpressTest;

public interface IMockCountVerifierCreator<TMock, TAsserter>
{
    IMockCountVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
    );
    
    IMockCountVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
    
    IMockCountVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
    );
    
    IMockCountVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
    );
}
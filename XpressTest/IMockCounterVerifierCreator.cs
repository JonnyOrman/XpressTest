using System.Linq.Expressions;

namespace XpressTest;

public interface IMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
    );
    
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
    
    IMockCounterVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
    );
    
    IMockCounterVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
    );
}
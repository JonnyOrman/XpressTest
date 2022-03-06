using System.Linq.Expressions;

namespace XpressTest;

public interface IMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
    
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
    );
    
    IMockCounterVerifier<TAsserter> Create(
        Func<IArrangement, Expression<System.Action<TMock>>> func,
        TAsserter asserter
    );
}
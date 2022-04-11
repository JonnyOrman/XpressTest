using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockVerifier<TSut, TMock>
{
    IMockCounterVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
    
    IMockCounterVerifier<IVoidAsserter<TSut>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        );
    
    IMockCounterVerifier<IVoidAsserter<TSut>> Should(
        Expression<Action<TMock>> expression
    );
}
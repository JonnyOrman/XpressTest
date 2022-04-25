using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockVerifier<TSut, TMock>
{
    IMockCountVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
    
    IMockCountVerifier<IVoidAsserter<TSut>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        );
    
    IMockCountVerifier<IVoidAsserter<TSut>> Should(
        Expression<Action<TMock>> expression
    );
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockVerifier<TSut, TMock>
{
    IMockCounterVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func
        );
    
    IMockCounterVerifier<IVoidAsserter<TSut>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
    
    IMockCounterVerifier<IVoidAsserter<TSut>> Should(
        Func<IArrangement, Expression<System.Action<TMock>>> func
        );
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IAsyncResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        );
    
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
    );
    
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
}
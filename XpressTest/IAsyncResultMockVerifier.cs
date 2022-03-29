using System.Linq.Expressions;

namespace XpressTest;

public interface IAsyncResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should(
        Func<IArrangement, Expression<System.Action<TMock>>> func
        );
    
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func
    );
    
    IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
        );
    
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
    
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
    );
    
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Expression<Action<TMock>> expression
    );
}
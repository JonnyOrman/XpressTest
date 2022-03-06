using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func
        );
    
    IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
}
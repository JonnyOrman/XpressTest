using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockVerifier<TSut, TSutResult, TMock>
{
    IResultMockCounterVerifier<TSut, TSutResult> Should<TResult>(Func<IArrangement, Expression<Func<TMock, TResult>>> func);
    
    IResultMockCounterVerifier<TSut, TSutResult> Should<TResult>(Expression<Func<TMock, TResult>> func);
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockVerifier<TSut, TMock>
{
    IVoidMockCounterVerifier<TSut> Should<TResult>(Func<IArrangement, Expression<Func<TMock, TResult>>> func);
    
    IVoidMockCounterVerifier<TSut> Should<TResult>(Expression<Func<TMock, TResult>> func);
    
    IVoidMockCounterVerifier<TSut> Should(Func<IArrangement, Expression<System.Action<TMock>>> func);
}
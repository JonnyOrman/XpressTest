using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockVerifier<TSut, TAssertion, TMock>
{
    IVoidMockCounterVerifier<TSut, TAssertion> Should<TResult>(Func<IArrangement, Expression<Func<TMock, TResult>>> func);
}
using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockVerifier<TSut, TMock> : IVoidMockVerifier<TSut, TMock>
    where TSut : class
    where TMock : class
{
    private readonly Mock<TMock> _mock;
    private readonly ISutComposer<TSut> _sutComposer;

    public VoidMockVerifier(
        Mock<TMock> mock,
        ISutComposer<TSut> sutComposer
        )
    {
        _mock = mock;
        _sutComposer = sutComposer;
    }
    
    public IVoidMockCounterVerifier<TSut> Should<TResult>(Func<IArrangement, Expression<Func<TMock, TResult>>> func)
    {
        throw new NotImplementedException();
    }

    public IVoidMockCounterVerifier<TSut> Should<TResult>(Expression<Func<TMock, TResult>> func)
    {
        return new VoidMockCounterVerifier<TSut, TMock, TResult>(
            _mock,
            func,
            _sutComposer
        );
    }

    public IVoidMockCounterVerifier<TSut> Should(Func<IArrangement, Expression<System.Action<TMock>>> func)
    {
        return new ArrangementVoidMockCounterVerifier<TSut, TMock>(
            _mock,
            func,
            _sutComposer
        );
    }
}
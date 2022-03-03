using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementVoidMockCounterVerifier<TSut, TMock> : IVoidMockCounterVerifier<TSut>
    where TSut : class
    where TMock : class
{
    private readonly Mock<TMock> _mock;
    private readonly Func<IArrangement, Expression<System.Action<TMock>>> _func;
    private readonly ISutComposer<TSut> _sutComposer;

    public ArrangementVoidMockCounterVerifier(
        Mock<TMock> mock,
        Func<IArrangement, Expression<System.Action<TMock>>> func,
        ISutComposer<TSut> sutComposer
        )
    {
        _mock = mock;
        _func = func;
        _sutComposer = sutComposer;
    }
    
    public IVoidAsserter<TSut> Once()
    {
        _mock.Verify(_func.Invoke(_sutComposer.Arrangement), Times.Once);

        return new VoidAsserter<TSut>(
            _sutComposer
        );
    }

    public IVoidAsserter<TSut> Never()
    {
        _mock.Verify(_func.Invoke(_sutComposer.Arrangement), Times.Never);

        return new VoidAsserter<TSut>(
            _sutComposer
        );
    }
}
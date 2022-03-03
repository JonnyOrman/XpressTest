using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockCounterVerifier<TSut, TMock, TMockResult> : IVoidMockCounterVerifier<TSut>
    where TSut : class
    where TMock : class
{
    private readonly Mock<TMock> _mock;
    private readonly Expression<Func<TMock, TMockResult>> _func;
    private readonly ISutComposer<TSut> _sutComposer;

    public VoidMockCounterVerifier(
        Mock<TMock> mock,
        Expression<Func<TMock, TMockResult>> func,
        ISutComposer<TSut> sutComposer
        )
    {
        _mock = mock;
        _func = func;
        _sutComposer = sutComposer;
    }
    
    public IVoidAsserter<TSut> Once()
    {
        _mock.Verify(_func, Times.Once);

        return new VoidAsserter<TSut>(
            _sutComposer
        );
    }

    public IVoidAsserter<TSut> Never()
    {
        _mock.Verify(_func, Times.Never);

        return new VoidAsserter<TSut>(
            _sutComposer
        );
    }
}
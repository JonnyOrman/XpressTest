using System.Linq.Expressions;

namespace XpressTest;

public class MockSetup<TMock, TResult>
{
    public MockSetup(
        Expression<Func<TMock, TResult>> when,
        TResult then
        )
    {
        When = when;
        Then = then;
    }

    public Expression<Func<TMock, TResult>> When { get; }

    public TResult Then { get; }
}
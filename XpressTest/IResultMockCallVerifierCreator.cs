using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockCallVerifierCreator<TMock, TAsserter>
{
    IMockCallVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
}
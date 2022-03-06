using System.Linq.Expressions;

namespace XpressTest;

public interface IMockCallCountVerifierCreator<TMock>
    where TMock : class
{
    IMockCallCountVerifier Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
    
    IMockCallCountVerifier Create(
        Expression<System.Action<TMock>> expression
    );
}
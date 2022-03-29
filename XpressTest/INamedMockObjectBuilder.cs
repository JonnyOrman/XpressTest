using System.Linq.Expressions;

namespace XpressTest;

public interface INamedMockObjectBuilder<TSut, TMock>
{
    INamedMockResultObjectBuilder<TSut, TMock, TResult> ThatDoes<TResult>(
        Expression<Func<TMock, TResult>> expression
    );
    
    INamedMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>(
        string name
    )
        where TNewObject : class;

    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
        );
}
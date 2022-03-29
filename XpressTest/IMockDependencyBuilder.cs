using System.Linq.Expressions;

namespace XpressTest;

public interface IMockDependencyBuilder<TSut, TDependency>
{
    IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class;

    IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
    );

    INamedDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
    )
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;

    INamedMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(string name)
        where TNewDependency : class;

    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func);

    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func);

    IVoidAsserter<TSut> WhenIt(System.Action<TSut> action);

    IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func);

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
    );

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );

    IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TDependency, TResult>>> func
    );

    IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Expression<Func<TDependency, TResult>> expression
    );

    IMockAsyncResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(
        Func<IArrangement, Expression<Func<TDependency, Task<TResult>>>> func
    );

    IMockAsyncResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(
        Expression<Func<TDependency, Task<TResult>>> expression
    );

    IExistingObjectBuilder<TSut> WithNamedObject<TObject>(string objectName);
}
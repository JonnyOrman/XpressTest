namespace XpressTest;

public class DependencyBuilder<TSut, TDependency>
    :
        Builder<TDependency, IDependencyBuilderChainer<TSut>>,
    IDependencyBuilder<TSut>
    where TSut : class
    where TDependency : class
{
    public DependencyBuilder(
        TDependency dependency,
        IObjectSetter<TDependency> setter,
        IDependencyBuilderChainer<TSut> dependencyBuilderChainer
            )
        : base(
            dependency,
            setter,
            dependencyBuilderChainer
            )
    {
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => _chainer.ComposeDependencyBuilder(
            newDependency
        ));
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        throw new NotImplementedException();

        // return Chain(() => _chainer.ComposeDependencyBuilder(
        //     newDependency,
        //     name
        // ));
    }
    
    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeMockDependencyBuilder<TNewDependency>());
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(string name)
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        return Chain(() => _chainer.ComposeAsserter());
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return Chain(() => _chainer.ComposeAsserter(
            func
            ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return Chain(() => _chainer.ComposeAsserter(
            action
            ));
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _chainer.ComposeAsserter(
            func
        );
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<IAction<TSut>, Task<TResult>> func)
    {
        throw new NotImplementedException();
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        throw new NotImplementedException();
    }
}
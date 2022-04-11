namespace XpressTest;

public class DependencyBuilder<TSut, TDependency>
    :
        Builder<TDependency, IDependencyBuilderChainer<TSut>>,
        IDependencyBuilder<TSut>
    where TSut : class
{
    public DependencyBuilder(
        TDependency dependency,
        IArrangementSetter<TDependency> valueDependencySetter,
        IDependencyBuilderChainer<TSut> valueDependencyBuilderChainer
    )
        : base(
            dependency,
            valueDependencySetter,
            valueDependencyBuilderChainer
        )
    {
    }

    public ISutPropertyTargeter<TSut> WhenItIsConstructed()
    {
        return Chain(() => _chainer.StartSutAsserter());
    }

    public IVoidAsserter<TSut> WhenIt(Action<TSut> func)
    {
        return Chain(() => _chainer.StartVoidAsserter(
            func
        ));
    }

    public IMockDependencySetupBuilder<TSut, TMockDependency> WithA<TMockDependency>()
        where TMockDependency : class
    {
        return Chain(() => _chainer.StartMockDependencyBuilder<TMockDependency>());
    }

    public IMockDependencySetupBuilder<TSut, TMockDependency> WithA<TMockDependency>(string name)
        where TMockDependency : class
    {
        return Chain(() => _chainer.StartNamedMockDependencyBuilder<TMockDependency>(name));
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => _chainer.StartValueDependencyBuilder(newDependency));
    }

    public IMockDependencySetupBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => _chainer.StartExistingMockDependencyBuilder<TMock>());
    }

    public IDependencyBuilder<TSut> WithThe<TObject>(string name)
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TObject>(
            name
        ));
    }

    public IDependencyBuilder<TSut> WithThe<TNewDependency>()
    {
        return Chain(() => _chainer.ComposeDependencyBuilder<TNewDependency>());
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
    )
    {
        return Chain(() => _chainer.ComposeDependencyBuilder(
            newDependency,
            name
        ));
    }

    public IVoidAsserter<TSut> WhenIt(Action<ISutArrangement<TSut>> func)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        return Chain(() => _chainer.StartResultAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        throw new NotImplementedException();
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            func
        ));
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<ISutArrangement<TSut>, Task<TResult>> func)
    {
        _objectSetter.Set(_obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await _chainer.ComposeMockAsserter(
            func
        ));

        return task.Result;
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        _objectSetter.Set(_obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await _chainer.ComposeMockAsserter(
            func
        ));
    
        return task.Result;
    }
}
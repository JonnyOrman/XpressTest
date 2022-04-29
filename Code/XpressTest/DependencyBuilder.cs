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
        return Chain(() => Chainer.StartSutAsserter());
    }

    public IVoidAsserter<TSut> WhenIt(Action<TSut> func)
    {
        return Chain(() => Chainer.StartVoidAsserter(
            func
        ));
    }

    public IMockDependencySetupBuilder<TSut, TMockDependency> WithA<TMockDependency>()
        where TMockDependency : class
    {
        return Chain(() => Chainer.StartNewMockDependencyBuilder<TMockDependency>());
    }

    public IMockDependencySetupBuilder<TSut, TMockDependency> WithA<TMockDependency>(string name)
        where TMockDependency : class
    {
        return Chain(() => Chainer.StartNewMockDependencyBuilder<TMockDependency>(name));
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => Chainer.StartNewObjectDependencyBuilder(newDependency));
    }

    public IMockDependencySetupBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => Chainer.StartNewExistingMockDependencyBuilder<TMock>());
    }

    public IDependencyBuilder<TSut> WithThe<TObject>(string name)
    {
        return Chain(() => Chainer.StartNewExistingObjectDependencyBuilder<TObject>(
            name
        ));
    }

    public IDependencyBuilder<TSut> WithThe<TNewDependency>()
    {
        return Chain(() => Chainer.StartNewExistingObjectDependencyBuilder<TNewDependency>());
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
    )
    {
        return Chain(() => Chainer.StartNewObjectDependencyBuilder(
            newDependency,
            name
        ));
    }

    public IVoidAsserter<TSut> WhenIt(Action<ISutArrangement<TSut>> func)
    {
        return Chain(() => Chainer.StartVoidAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<ISutArrangement<TSut>, Task<TResult>> func)
    {
        ObjectSetter.Set(Obj);

        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await Chainer.StartAsyncResultAsserter(
            func
        ));

        return task.Result;
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        ObjectSetter.Set(Obj);

        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await Chainer.StartAsyncResultAsserter(
            func
        ));

        return task.Result;
    }
}
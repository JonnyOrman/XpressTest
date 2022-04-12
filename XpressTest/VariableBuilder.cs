namespace XpressTest;

public class VariableBuilder<TSut, TObject, TChainer>
    :
        Builder<TObject, TChainer>,
        IVariableBuilder<TSut>
    where TSut : class
    where TChainer : IVariableBuilderChainer<TSut>
{
    public VariableBuilder(
        TObject namedObject,
        IArrangementSetter<TObject> namedObjectSetter,
        TChainer namedObjectBuilderChainer
        )
        : base(
            namedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        )
    {
    }

    public IMockSetupBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        return Chain(() => _chainer.StartNewMockObjectBuilder<TNewObject>());
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
        )
    {
        return Chain(() => _chainer.StartNewObjectBuilder(
            obj
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
        )
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            obj,
            name
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func
        )
    {
        return Chain(() => _chainer.StartNewObjectBuilder(
            func
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func,
        string name
        )
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            func,
            name
        ));
    }

    public IDependencyBuilder<TSut> WithThe<TNamedObject>(
        string objectName
    )
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TNamedObject>(
            objectName
        ));
    }

    public IMockDependencySetupBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => _chainer.StartExistingMockDependencyBuilder<TMock>());
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
        )
    {
        return Chain(() => _chainer.ComposeAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        return Chain(() => _chainer.ComposeAsserter(
            func
        ));
    }

    public IVoidAsserter<TSut> WhenIt(
        Action<ISutArrangement<TSut>> func
        )
    {
        return Chain(() => _chainer.ComposeAsserter(
            func
        ));
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewMockDependencyBuilder<TNewDependency>());
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => _chainer.ComposeValueDependencyBuilder(
            newDependency
        ));
    }

    public IDependencyBuilder<TSut> WithThe<TNewDependency>()
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TNewDependency>());
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
    {
        return Chain(() => _chainer.StartNewNamedDependencyBuilder(
            newDependency,
            name
            ));
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewNamedMockDependencyBuilder<TNewDependency>(
            name
        ));
    }
    
    public IDependencyBuilder<TSut> With<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    )
    {
        return Chain(() => _chainer.ComposeValueDependencyBuilder(
            newDependencyFunc
        ));
    }

    public IMockSetupBuilder<TSut, TNewObject> AndGivenA<TNewObject>(
        string name
        )
        where TNewObject : class
    {
        return Chain(() => _chainer.StartNewNamedMockObjectBuilder<TNewObject>(
            name
            ));
    }

    public IVoidAsserter<TSut> WhenIt(Action<TSut> action)
    {
        return Chain(() => _chainer.ComposeAsserter(
            action
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return Chain(() => _chainer.ComposeAsserter(
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

    public ISutPropertyTargeter<TSut> WhenItIsConstructed()
    {
        return Chain(() => _chainer.StartSutAsserter());
    }
}
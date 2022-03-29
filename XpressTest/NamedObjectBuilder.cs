namespace XpressTest;

public class NamedObjectBuilder<TSut, TObject>
    :
        Builder<INamedObject<TObject>, INamedObjectBuilderChainer<TSut>>,
        IObjectBuilder<TSut>
    where TSut : class
{
    public NamedObjectBuilder(
        INamedObject<TObject> namedObject,
        INamedObjectSetter<TObject> namedObjectSetter,
        INamedObjectBuilderChainer<TSut> namedObjectBuilderChainer
        )
        : base(
            namedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        )
    {
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        return Chain(() => _chainer.StartNewMockObjectBuilder<TNewObject>());
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
        )
    {
        return Chain(() => _chainer.StartNewObjectBuilder(
            obj
        ));
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
        )
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            obj,
            name
        ));
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func
        )
    {
        return Chain(() => _chainer.StartNewObjectBuilder(
            func
        ));
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func,
        string name
        )
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            func,
            name
        ));
    }

    public IExistingObjectBuilder<TSut> With<TNamedObject>(
        string objectName
    )
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TNamedObject>(
            objectName
        ));
    }

    public IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => _chainer.StartExistingMockDependencyBuilder<TMock>());
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        return Chain(() => _chainer.Compose(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<TSut, TResult> func
        )
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(
        System.Action<TSut> action
        )
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
        )
    {
        return Chain(() => _chainer.Compose(
            func
        ));
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
        )
    {
        throw new NotImplementedException();
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
        )
    {
        throw new NotImplementedException();
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
        )
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
    where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            newDependency,
            name
        ));
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewMockDependencyBuilder<TNewDependency>());
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }
}
namespace XpressTest;

public class ObjectBuilder<TSut, TObject>
    :
        Builder<TObject, IObjectBuilderChainer<TSut>>,
        IObjectBuilder<TSut>
    where TSut : class
{
    public ObjectBuilder(
        TObject obj,
        IObjectSetter<TObject> objectSetter,
        IObjectBuilderChainer<TSut> objectBuilderChainer
        )
    : base(
        obj,
        objectSetter,
        objectBuilderChainer
        )
    {
    } 

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
    )
    {
        return Chain(
            () => _chainer.ComposeResultAsserter(
                func
            )
        );
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
        return Chain(
            () => _chainer.ComposeVoidAsserter(
                func
            )
        );
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
        )
    {
        throw new NotImplementedException();
    }
    
    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        throw new NotImplementedException();
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(
            () => _chainer.ComposeExistingObjectBuilder<TNewDependency>()
        );
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
    )
    {
        return Chain(
            () => _chainer.ComposeValueDependencyBuilder(
                newDependency
            )
        );
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(
            () => _chainer.ComposeMockDependencyBuilder<TNewDependency>()
        );
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

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        return Chain(
            () => _chainer.ComposeMockObjectBuilder<TNewObject>()
        );
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
    )
    {
        return Chain(
            () => _chainer.ComposeObjectBuilder(
                obj
            )
        );
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
    )
    {
        return Chain(
            () => _chainer.ComposeObjectBuilder(
                obj,
                name
            )
        );
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func
    )
    {
        return Chain(
            () => _chainer.ComposeObjectBuilder(
                func
            )
        );
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func,
        string name
    )
    {
        return Chain(
            () => _chainer.ComposeObjectBuilder(
                func,
                name
            )
        );
    }

    public IExistingObjectBuilder<TSut> With<TNamedObject>(string objectName)
    {
        return Chain(
            () => _chainer.ComposeExistingObjectBuilder<TNamedObject>(
                    objectName
                )
        );
    }

    public IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(
            () => _chainer.ComposeMockDependencyBuilder2<TMock>()
            );
    }
}

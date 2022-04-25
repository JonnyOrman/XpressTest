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
        return Chain(() => Chainer.StartNewMockObjectBuilder<TNewObject>());
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
        )
    {
        return Chain(() => Chainer.StartNewObjectBuilder(
            obj
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
        )
    {
        return Chain(() => Chainer.StartNewNamedObjectBuilder(
            obj,
            name
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func
        )
    {
        return Chain(() => Chainer.StartNewObjectBuilder(
            func
        ));
    }

    public IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func,
        string name
        )
    {
        return Chain(() => Chainer.StartNewNamedObjectBuilder(
            func,
            name
        ));
    }

    public IDependencyBuilder<TSut> WithThe<TNamedObject>(
        string objectName
    )
    {
        return Chain(() => Chainer.StartNewExistingObjectDependencyBuilder<TNamedObject>(
            objectName
        ));
    }

    public IMockDependencySetupBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => Chainer.StartNewExistingMockDependencyBuilder<TMock>());
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
        )
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
        )
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IVoidAsserter<TSut> WhenIt(
        Action<ISutArrangement<TSut>> action
        )
    {
        return Chain(() => Chainer.StartVoidAsserter(
            action
        ));
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(() => Chainer.StartNewMockDependencyBuilder<TNewDependency>());
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => Chainer.StartNewObjectDependencyBuilder(
            newDependency
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

    public IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return Chain(() => Chainer.StartNewMockDependencyBuilder<TNewDependency>(
            name
        ));
    }
    
    public IDependencyBuilder<TSut> With<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    )
    {
        return Chain(() => Chainer.StartExistingObjectDependencyBuilder(
            newDependencyFunc
        ));
    }

    public IMockSetupBuilder<TSut, TNewObject> AndGivenA<TNewObject>(
        string name
        )
        where TNewObject : class
    {
        return Chain(() => Chainer.StartNewNamedMockObjectBuilder<TNewObject>(
            name
            ));
    }

    public IVoidAsserter<TSut> WhenIt(
        Action<TSut> action
        )
    {
        return Chain(() => Chainer.StartVoidAsserter(
            action
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<TSut, TResult> func
        )
    {
        return Chain(() => Chainer.StartResultAsserter(
            func
        ));
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
        )
    {
        ObjectSetter.Set(Obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await Chainer.StartAsyncResultAsserter(
            func
        ));

        return task.Result;
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
        )
    {
        ObjectSetter.Set(Obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await Chainer.StartAsyncResultAsserter(
            func
        ));

        return task.Result;
    }

    public ISutPropertyTargeter<TSut> WhenItIsConstructed()
    {
        return Chain(() => Chainer.StartSutAsserter());
    }
}
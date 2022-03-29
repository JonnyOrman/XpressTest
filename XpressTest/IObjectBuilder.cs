namespace XpressTest;

public interface IObjectBuilder<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
    );

    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
    );

    IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class;

    IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
    );

    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;

    IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class;

    IObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
    );

    INamedObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
    );

    IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func
    );

    INamedObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func,
        string name
    );

    IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;
}
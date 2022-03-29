namespace XpressTest;

public interface INamedObjectBuilder<TSut>
{
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

    IExistingObjectBuilder<TSut> With<TNamedObject>(
        string objectName
    );

    IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;

    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
    );

    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IArrangement, Func<TSut, TResult>> func);

    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
    );

    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
}
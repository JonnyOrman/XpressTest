namespace XpressTest;

public interface IObjectBuilder<TSut> : IDependencyBuilder<TSut>
{
    IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class;
    
    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj);

    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name);

    IObjectBuilder<TSut> AndGiven<TNewObject>(Func<IArrangement, TNewObject> func);

    IObjectBuilder<TSut> AndGiven<TNewObject>(Func<IArrangement, TNewObject> func, string name);
    
    IExistingObjectBuilder<TSut> With<TNamedObject>(string objectName);
    
    IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;
}
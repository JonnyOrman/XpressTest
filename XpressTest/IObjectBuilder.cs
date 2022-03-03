namespace XpressTest;

public interface IObjectBuilder<TSut> : IDependencyBuilder<TSut>
{
    IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class;

    IObjectBuilder<TSut> AndGiven<TNewObject>();
    
    IObjectBuilder<TSut> AndGivenA<TNewObject>(string name);

    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj);

    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name);
}
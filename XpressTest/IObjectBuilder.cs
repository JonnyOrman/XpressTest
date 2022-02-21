namespace XpressTest;

public interface IObjectBuilder<TSut> : IDependencyBuilder<TSut>
{
    IObjectBuilder<TSut> AndGivenA<TNewObject>();

    IObjectBuilder<TSut> AndGiven<TNewObject>();
    
    IObjectBuilder<TSut> AndGivenA<TNewObject>(string name);

    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name);
}
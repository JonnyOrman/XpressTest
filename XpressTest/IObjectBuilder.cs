namespace XpressTest;

public interface IObjectBuilder<TSut> : IDependencyBuilder<TSut>
{
    IObjectBuilder<TSut> AndA<TNewObject>();

    IObjectBuilder<TSut> And<TNewObject>();
    
    IObjectBuilder<TSut> AndA<TNewObject>(string name);

    IObjectBuilder<TSut> And<TNewObject>(TNewObject obj, string name);
}
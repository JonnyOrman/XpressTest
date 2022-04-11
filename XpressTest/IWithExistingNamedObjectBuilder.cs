namespace XpressTest;

public interface IWithExistingNamedObjectBuilder<TSut>
{
    IDependencyBuilder<TSut> WithThe<TObject>(string name);
}
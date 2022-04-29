namespace XpressTest;

public interface IGivenNamedObjectBuilder<TSut>
{
    IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
    );
}
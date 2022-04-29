namespace XpressTest;

public interface IGivenObjectBuilder<TSut>
{
    IVariableBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj
        );
}
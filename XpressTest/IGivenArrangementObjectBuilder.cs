namespace XpressTest;

public interface IGivenArrangementObjectBuilder<TSut>
{
    IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func
    );
}
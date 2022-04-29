namespace XpressTest;

public interface IGivenNamedArrangementObjectBuilder<TSut>
{
    IVariableBuilder<TSut> AndGiven<TNewObject>(
        Func<IReadArrangement, TNewObject> func,
        string name
    );
}
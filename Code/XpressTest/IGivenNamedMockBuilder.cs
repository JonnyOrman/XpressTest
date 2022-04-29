namespace XpressTest;

public interface IGivenNamedMockBuilder<TSut>
{
    IMockSetupBuilder<TSut, TNewObject> AndGivenA<TNewObject>(
        string name
        )
        where TNewObject : class;
}
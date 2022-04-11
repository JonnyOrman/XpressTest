namespace XpressTest;

public interface IGivenAMockBuilder<TSut>
{
    IMockSetupBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class;
}
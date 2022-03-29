namespace XpressTest;

public interface IMockObjectBuilderCreator<TSut>
{
    IMockObjectBuilder<TSut, TNewObject> Create<TNewObject>()
        where TNewObject : class;
}
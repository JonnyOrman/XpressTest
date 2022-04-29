namespace XpressTest;

public interface INamedMockSetupBuilderCreator<TSut>
{
    IMockSetupBuilder<TSut, TObject> Create<TObject>(
        string name
        )
        where TObject : class;
}
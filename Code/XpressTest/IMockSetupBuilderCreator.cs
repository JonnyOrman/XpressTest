namespace XpressTest;

public interface IMockSetupBuilderCreator<TSut>
{
    IMockSetupBuilder<TSut, TObject> Create<TObject>()
        where TObject : class;
}
namespace XpressTest;

public interface IVariableBuilderCreator<TSut>
where TSut : class
{
    IVariableBuilder<TSut> Create<TObject>(
        TObject obj
        );

    IVariableBuilder<TSut> Create<TObject>(
        TObject obj,
        string name
    );

    IVariableBuilder<TSut> Create<TObject>(
        Func<IReadArrangement, TObject> func
    );

    IVariableBuilder<TSut> Create<TObject>(
        Func<IReadArrangement, TObject> func,
        string name
    );
}
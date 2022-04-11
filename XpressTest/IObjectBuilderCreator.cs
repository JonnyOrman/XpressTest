namespace XpressTest;

public interface IObjectBuilderCreator<TSut>
where TSut : class
{   
    IVariableBuilder<TSut> Create<TObject>(
        TObject obj
        );
    
    IVariableBuilder<TSut> Create<TObject>(
        TObject obj,
        string name
    );
    
    IDependencyBuilder<TSut> Create<TObject>();
    
    IDependencyBuilder<TSut> Create<TObject>(
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
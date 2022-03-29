namespace XpressTest;

public interface IObjectBuilderCreator<TSut>
where TSut : class
{   
    IObjectBuilder<TSut> Create<TObject>(
        TObject obj
        );
    
    INamedObjectBuilder<TSut> Create<TObject>(
        TObject obj,
        string name
    );
    
    IExistingObjectBuilder<TSut> Create<TObject>();
    
    IExistingObjectBuilder<TSut> Create<TObject>(
        string name
    );
    
    IObjectBuilder<TSut> Create<TObject>(
        Func<IArrangement, TObject> func
    );
    
    INamedObjectBuilder<TSut> Create<TObject>(
        Func<IArrangement, TObject> func,
        string name
    );
}
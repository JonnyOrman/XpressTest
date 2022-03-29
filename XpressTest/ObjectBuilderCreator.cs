namespace XpressTest;

public class ObjectBuilderCreator<TSut>
    :
        IObjectBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;

    private readonly IObjectBuilderChainer<TSut> _objectBuilderChainer;

    private INamedObjectBuilderChainer<TSut> _namedObjectBuilderChainer;

    private readonly IExistingObjectBuilder<TSut> _existingObjectBuilder;

    public ObjectBuilderCreator(
        IArrangement arrangement,
        IObjectBuilderChainer<TSut> objectBuilderChainer,
        INamedObjectBuilderChainer<TSut> namedObjectBuilderChainer,
        IExistingObjectBuilder<TSut> existingObjectBuilder
        )
    {
        _arrangement = arrangement;
        _objectBuilderChainer = objectBuilderChainer;
        _namedObjectBuilderChainer = namedObjectBuilderChainer;
        _existingObjectBuilder = existingObjectBuilder;
    }
    
    public IObjectBuilder<TSut> Create<TObject>(TObject obj)
    {
        var objectSetter = new ObjectSetter<TObject>(
            _arrangement
        );

        return new ObjectBuilder<TSut, TObject>(
            obj,
            objectSetter,
            _objectBuilderChainer
        );
    }

    public IObjectBuilder<TSut> Create<TObject>(TObject obj, string name)
    {
        var namedObjectSetter = new NamedObjectSetter<TObject>(
            _arrangement
        );

        var newNamedObject = new NamedObject<TObject>(
            obj,
            name
            );
        
        return new NamedObjectBuilder<TSut, TObject>(
            newNamedObject,
            namedObjectSetter,
            _namedObjectBuilderChainer
        );
    }

    public IExistingObjectBuilder<TSut> Create<TObject>()
    {
        var dependency = _arrangement.GetThe<TObject>();
        
        _arrangement.AddDependency(dependency);

        return _existingObjectBuilder;
    }

    public IExistingObjectBuilder<TSut> Create<TObject>(string name)
    {
        var existingObject = _arrangement.GetObject<TObject>(
            name
            );
        
        _arrangement.AddDependency(existingObject);
        
        return _existingObjectBuilder;
    }

    public IObjectBuilder<TSut> Create<TObject>(Func<IArrangement, TObject> func)
    {
        var newObject = func.Invoke(_arrangement);
        
        var objectSetter = new ObjectSetter<TObject>(
            _arrangement
        );

        return new ObjectBuilder<TSut, TObject>(
            newObject,
            objectSetter,
            _objectBuilderChainer
        );
    }

    public IObjectBuilder<TSut> Create<TObject>(Func<IArrangement, TObject> func, string name)
    {
        var newObject = func.Invoke(_arrangement);
        
        var namedObjectSetter = new NamedObjectSetter<TObject>(
            _arrangement
        );

        var newNamedObject = new NamedObject<TObject>(
            newObject,
            name
            );
        
        var builder = new NamedObjectBuilder<TSut, TObject>(
            newNamedObject,
            namedObjectSetter,
            _namedObjectBuilderChainer
        );

        return builder;
    }

    public void Set(NamedObjectBuilderChainer<TSut> namedObjectBuilderChainer)
    {
        _namedObjectBuilderChainer = namedObjectBuilderChainer;
    }
}
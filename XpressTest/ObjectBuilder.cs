using Moq;

namespace XpressTest;

public class ObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly TObject _obj;
    private readonly string _name;
    private readonly IObjectCollection _objects;

    public ObjectBuilder(
        TObject obj,
        string name,
        IObjectCollection objects
        )
    {
        _obj = obj;
        _name = name;
        _objects = objects;
    }

    public IObjectBuilder<TSut> AndA<TNewObject>()
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> And<TNewObject>()
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndA<TNewObject>(string name)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> And<TNewObject>(TNewObject obj, string name)
    {
        var objct = new Object<TObject>(
            _obj,
            _name
            );
        
        _objects.Add(objct);
        
        var builder = new ObjectBuilder<TSut, TNewObject>(
            obj,
            name,
            _objects
        );

        return builder;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var obj = new Object<TObject>(
            _obj,
            _name
            );
        
        _objects.Add(obj);

        var dependencies = new DependencyCollection();
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            dependencies,
            _objects
        );

        return builder;
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        var objct = new Object<TObject>(
            _obj,
            _name
        );
        
        _objects.Add(objct);
        
        var dependencyMock = new Mock<TNewDependency>();

        var dependencies = new DependencyCollection();
        
        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            dependencies,
            _objects
        );

        return builder;
    }
}
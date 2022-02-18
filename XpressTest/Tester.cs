namespace XpressTest;

public abstract class Tester<TSut, TAssertion> : ITester
    where TSut : class
{
    protected readonly TAssertion _assertion;
    protected readonly IDependencyCollection _dependencies;
    protected readonly IObjectCollection _objects;

    protected Tester(
        TAssertion assertion,
        IDependencyCollection dependencies,
        IObjectCollection objects
        )
    {
        _assertion = assertion;
        _dependencies = dependencies;
        _objects = objects;
    }

    public void Test()
    {
        object sut = null;

        if (_dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in _dependencies.GetAll())
            {
                parameters.Add(dependency.Object);
            }

            sut = Activator.CreateInstance(typeof(TSut), parameters.ToArray());
        }
        else
        {
            sut = Activator.CreateInstance<TSut>();
        }
        
        var typedSut = sut as TSut;

        ActAndAssert(typedSut);
    }

    protected abstract void ActAndAssert(TSut sut);
}
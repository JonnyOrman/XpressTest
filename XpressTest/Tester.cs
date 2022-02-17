namespace XpressTest;

public abstract class Tester<TSut, TAssertion> : ITester
    where TSut : class
{
    protected readonly TAssertion _assertion;
    private readonly ICollection<IDependency> _dependencies;

    protected Tester(
        TAssertion assertion,
        ICollection<IDependency> dependencies
        )
    {
        _assertion = assertion;
        _dependencies = dependencies;
    }

    public void Test()
    {
        object sut = null;

        if (_dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in _dependencies)
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
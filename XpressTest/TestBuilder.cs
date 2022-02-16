using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public abstract class TestBuilder<TSut, TAction, TAssertion> : ITestBuilder<TAction, TAssertion>
    where TSut : class
{
    protected readonly ICollection<IDependency> _dependencies;
    
    protected TAction _func;
    
    protected TAssertion _assertion;

    public TestBuilder(ICollection<IDependency> dependencies)
    {
        _dependencies = dependencies;
    }
    
    public ITestBuilder<TAction, TAssertion> WithA<TDependency>()
        where TDependency : class
    {
        var mock = new Mock<TDependency>();
        
        _dependencies.Add(new MockDependency<TDependency>(mock));

        return this;
    }
    
    public ITestBuilder<TAction, TAssertion> That<TDependency, TDependencyResult>(Expression<Func<TDependency, TDependencyResult>> func, TDependencyResult dependencyResult)
        where TDependency : class
    {
        var mockDependency = _dependencies.Last() as MockDependency<TDependency>;

        var mock = mockDependency.Mock;
        
        mock.Setup(func).Returns(dependencyResult);

        return this;
    }
    
    public ITestBuilder<TAction, TAssertion> With<TDependency>(TDependency dependency)
        where TDependency : class
    {
        _dependencies.Add(new ValueDependency<TDependency>(dependency));

        return this;
    }

    public ITestBuilder<TAction, TAssertion> WhenIt(TAction func)
    {
        _func = func;

        return this;
    }

    public ITestBuilder<TAction, TAssertion> ThenItShould(TAssertion assertion)
    {
        _assertion = assertion;

        return this;
    }
    
    public void Test()
    {
        object sut = null;

        if(_dependencies.Any())
        {
            var parameters = new List<object>();

            foreach(var dependency in _dependencies)
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
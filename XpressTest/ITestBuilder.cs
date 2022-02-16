using System.Linq.Expressions;

namespace XpressTest;

public interface ITestBuilder<TAction, TAssertion>
{
    ITestBuilder<TAction, TAssertion> WithA<TDependency>()
        where TDependency : class;
    
    ITestBuilder<TAction, TAssertion> That<TDependency, TDependencyResult>(Expression<Func<TDependency, TDependencyResult>> func,
        TDependencyResult dependencyResult)
        where TDependency : class;

    ITestBuilder<TAction, TAssertion> With<TDependency>(TDependency dependency)
        where TDependency : class;
    
    ITestBuilder<TAction, TAssertion> WhenIt(TAction func);
    
    ITestBuilder<TAction, TAssertion> ThenItShould(TAssertion assertion);

    void Test();
}
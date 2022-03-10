using System.Linq.Expressions;

namespace XpressTest;

public interface IMockDependencyBuilder<TSut, TDependency> : IDependencyBuilder<TSut>
{
    IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TDependency, TResult>>> func
    );
    
    IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Expression<Func<TDependency, TResult>> expression
    );

    IObjectBuilder<TSut> WithNamedObject<TObject>(string objectName);
}
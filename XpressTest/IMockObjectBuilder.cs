using System.Linq.Expressions;

namespace XpressTest;

public interface IMockObjectBuilder<TSut, TObject>
    :
        IObjectBuilder<TSut>
{
    IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TObject, TResult>>> func
    );

    IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    );

    IValueDependencyBuilder<TSut> With<TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
    );
}
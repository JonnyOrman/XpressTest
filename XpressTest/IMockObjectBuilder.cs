using System.Linq.Expressions;

namespace XpressTest;

public interface IMockObjectBuilder<TSut, TObject>
{
    IValueDependencyBuilder<TSut> With<TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
    );

    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;

    IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class;

    IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj);

    INamedObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
    );

    IObjectBuilder<TSut> AndGiven<TNewObject>(
        Func<IArrangement, TNewObject> func
        );

    IExistingObjectBuilder<TSut> With<TNamedObject>(
        string objectName
        );

    IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;

    IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TObject, TResult>>> func
    );

    IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    );
}
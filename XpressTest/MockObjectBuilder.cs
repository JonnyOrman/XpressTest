using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject>
    :
        Builder<Mock<TObject>, IMockObjectBuilderChainer<TSut>>,
        IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly IArrangement _arrangement;

    public MockObjectBuilder(
        Mock<TObject> mock,
        IMockObjectSetter<TObject> mockObjectSetter,
        IMockObjectBuilderChainer<TSut> mockObjectBuilderChainer,
        IArrangement arrangement
    )
        : base(
            mock,
            mockObjectSetter,
            mockObjectBuilderChainer
        )
    {
        _arrangement = arrangement;
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
        )
    {
        return Chain(() => _chainer.ComposeValueDependencyBuilder<TObject, TNewDependency>(
            newDependencyFunc
        ));
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewMockDependencyBuilder<TNewDependency>());
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        return Chain(() => _chainer.StartNewMockObjectBuilder<TNewObject>());
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj)
    {
        return Chain(() => _chainer.StartNewObjectBuilder(obj));
    }

    public INamedObjectBuilder<TSut> AndGiven<TNewObject>(
        TNewObject obj,
        string name
    )
    {
        return Chain(() => _chainer.StartNewNamedObjectBuilder(
            obj,
            name
        ));
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(Func<IArrangement, TNewObject> func)
    {
        return Chain(() => _chainer.StartNewObjectBuilder(
            func
        ));
    }

    public IExistingObjectBuilder<TSut> With<TNamedObject>(string objectName)
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TNamedObject>(
            objectName
        ));
    }

    public IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return Chain(() => _chainer.StartExistingMockDependencyBuilder<TMock>());
    }

    public IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TObject, TResult>>> func
        )
    {
        var expression = func.Invoke(_arrangement);

        return new MockResultObjectBuilder<TSut, TObject, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IMockResultObjectBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
        )
    {
        return new MockResultObjectBuilder<TSut, TObject, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }
}
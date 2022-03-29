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

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<IAction<TSut>, Task<TResult>> func)
    {
        throw new NotImplementedException();
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        throw new NotImplementedException();
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
        )
    {
        return Chain(() => _chainer.ComposeValueDependencyBuilder<TObject, TNewDependency>(
            newDependencyFunc
        ));
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return Chain(() => _chainer.StartNewMockDependencyBuilder<TNewDependency>());
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(string name)
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
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

    public IObjectBuilder<TSut> AndGiven<TNewObject>(
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

    public IObjectBuilder<TSut> AndGiven<TNewObject>(Func<IArrangement, TNewObject> func, string name)
    {
        throw new NotImplementedException();
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
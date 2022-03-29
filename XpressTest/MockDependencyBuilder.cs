using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencyBuilder<TSut, TDependency>
    :
    Builder<Mock<TDependency>, IMockDependencyBuilderChainer<TSut>>,
    IMockDependencyBuilder<TSut, TDependency>
    where TSut : class
    where TDependency : class
{
    private readonly IArrangement _arrangement;

    public MockDependencyBuilder(
        Mock<TDependency> dependencyMock,
        IObjectSetter<Mock<TDependency>> mockDependencySetter,
        IMockDependencyBuilderChainer<TSut> mockDependencyBuilderChainer,
        IArrangement arrangement
        )
        : base(
            dependencyMock,
            mockDependencySetter,
            mockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeDependencyBuilder<TNewDependency>());
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
        )
    {
        return Chain(() => _chainer.ComposeValueDependencyBuilder<TDependency, TNewDependency>(
            newDependency
        ));
    }

    public INamedDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeDependencyBuilder(
            newDependency,
            name
        ));
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeMockDependencyBuilder<TNewDependency>());
    }

    public INamedMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(string name)
        where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeNamedMockDependencyBuilder<TNewDependency>(
            name
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            func
        ));
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            func
        ));
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            action
        ));
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        return Chain(() => _chainer.ComposeMockAsserter(
            func
        ));
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
        )
    {
        _objectSetter.Set(_obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await _chainer.ComposeMockAsserter(
            func
        ));

        return task.Result;
    }

    public IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
        )
    {
        _objectSetter.Set(_obj);
        
        Task<IAsyncResultAsserter<TSut, TResult>> task = Task.Run(async () => await _chainer.ComposeMockAsserter(
            func
        ));

        return task.Result;
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TDependency, TResult>>> func
        )
    {
        var expression = func.Invoke(_arrangement);

        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _obj,
            this,
            _arrangement
            );
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Expression<Func<TDependency, TResult>> expression
        )
    {
        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(
        Func<IArrangement, Expression<Func<TDependency, Task<TResult>>>> func
        )
    {
        var expression = func.Invoke(_arrangement);
        
        return new MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(
        Expression<Func<TDependency, Task<TResult>>> expression
        )
    {
        return new MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IExistingObjectBuilder<TSut> WithNamedObject<TObject>(string objectName)
    {
        return Chain(() => _chainer.StartNewExistingObjectBuilder<TObject>(
            objectName
        ));
    }
}
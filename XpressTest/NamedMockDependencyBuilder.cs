using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockDependencyBuilder<TSut, TDependency>
    :
        Builder<INamedMock<TDependency>, INamedMockDependencyBuilderChainer<TSut>>,
        IMockDependencyBuilder<TSut, TDependency>
where TDependency : class
{
    private readonly IArrangement _arrangement;

    public NamedMockDependencyBuilder(
        INamedMock<TDependency> namedMock,
        IObjectSetter<INamedMock<TDependency>> setter,
        INamedMockDependencyBuilderChainer<TSut> namedMockDependencyBuilderChainer,
        IArrangement arrangement
            )
    : base(
        namedMock,
        setter,
        namedMockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        return Chain(() => _chainer.StartResultAsserter(
            func
        ));
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

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IExistingObjectBuilder<TSut> With<TNewDependency>() where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name) where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return Chain(() => _chainer.StartNamedMockDependencyBuilder<TNewDependency>(
            name
        ));
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TDependency, TResult>>> func
        )
    {
        var expression = func.Invoke(_arrangement);

        return new NamedMockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(Expression<Func<TDependency, TResult>> expression)
    {
        throw new NotImplementedException();
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(Func<IArrangement, Expression<Func<TDependency, Task<TResult>>>> func)
    {
        throw new NotImplementedException();
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoesAsync<TResult>(Expression<Func<TDependency, Task<TResult>>> expression)
    {
        throw new NotImplementedException();
    }

    public IExistingObjectBuilder<TSut> WithNamedObject<TObject>(string objectName)
    {
        throw new NotImplementedException();
    }
}
using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockDependencyBuilder<TSut, TDependency>
    :
        Builder<INamedMock<TDependency>, INamedMockDependencyBuilderChainer<TSut>>,
        INamedMockDependencyBuilder<TSut, TDependency>
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
    
    public INamedMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return Chain(() => _chainer.StartNamedMockDependencyBuilder<TNewDependency>(
            name
        ));
    }

    public INamedMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
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
}
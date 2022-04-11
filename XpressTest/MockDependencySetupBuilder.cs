using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencySetupBuilder<TSut, TObject, TMock>
:
    DependencyBuilder<TSut, TMock>,
    IMockDependencySetupBuilder<TSut, TObject>
where TSut : class
where TObject : class
where TMock : IMock<TObject>
{
    private readonly IArrangement _arrangement;

    public MockDependencySetupBuilder(
        TMock obj,
        IArrangement arrangement,
        IArrangementSetter<TMock> setter,
        IDependencyBuilderChainer<TSut> chainer
        )
    : base(
        obj,
        setter,
        chainer
        )
    {
        _arrangement = arrangement;
    }
    
    public IMockResultDependencyBuilder<TSut, TResult> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
        )
    {
        var expression = func.Invoke(_arrangement);

        return new MockResultDependencyBuilder<TSut, TObject, TResult>(
            expression,
            _obj,
            this,
            _arrangement
        );
    }

    public IMockResultDependencyBuilder<TSut, TResult> ThatDoes<TResult>(Expression<Func<TObject, TResult>> expression)
    {
        return _chainer.StartMockResultDependencyBuilder(
            expression,
            _obj,
            this
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(Func<IReadArrangement, Expression<Func<TObject, Task<TResult>>>> func)
    {
        return _chainer.StartMockAsyncResultDependencyBuilder(
            func,
            _obj,
            this
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(Expression<Func<TObject, Task<TResult>>> expression)
    {
        return _chainer.StartMockAsyncResultDependencyBuilder(
            expression,
            _obj,
            this
        );
    }
}
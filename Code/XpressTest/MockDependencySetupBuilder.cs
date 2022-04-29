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

    public IMockResultBuilder<TResult, IDependencyBuilder<TSut>> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
        )
    {
        var expression = func.Invoke(_arrangement);

        return new MockResultBuilder<TObject, TResult, IDependencyBuilder<TSut>>(
            expression,
            Obj,
            this,
            _arrangement
        );
    }

    public IMockResultBuilder<TResult, IDependencyBuilder<TSut>> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
        )
    {
        return Chainer.StartMockResultDependencyBuilder(
            expression,
            Obj,
            this
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, Task<TResult>>>> func
        )
    {
        return Chainer.StartMockAsyncResultDependencyBuilder(
            func,
            Obj,
            this
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(
        Expression<Func<TObject, Task<TResult>>> expression
        )
    {
        return Chainer.StartMockAsyncResultDependencyBuilder(
            expression,
            Obj,
            this
        );
    }
}
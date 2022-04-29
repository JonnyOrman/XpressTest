using System.Linq.Expressions;

namespace XpressTest;

public class MockSetupBuilder<TSut, TObject, TMock>
    :
        VariableBuilder<TSut, TMock, IMockBuilderChainer<TSut, TObject, TMock>>,
        IMockSetupBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public MockSetupBuilder(
        TMock mock,
        IArrangementSetter<TMock> mockObjectSetter,
        IMockBuilderChainer<TSut, TObject, TMock> mockObjectBuilderChainer
    )
        : base(
            mock,
            mockObjectSetter,
            mockObjectBuilderChainer
        )
    {
    }

    public IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    )
    {
        return Chainer.StartMockSetupResultBuilder(
            func,
            Obj,
            this
        );
    }

    public IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    )
    {
        return Chainer.StartMockSetupResultBuilder(
            expression,
            Obj,
            this
        );
    }
}
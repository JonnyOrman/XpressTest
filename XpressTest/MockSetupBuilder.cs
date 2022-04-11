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
    
    public IMockSetupResultBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    )
    {
        return _chainer.StartMockSetupResultBuilder(
            func,
            _obj,
            this
        );
    }
    
    public IMockSetupResultBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    )
    {
        return _chainer.StartMockSetupResultBuilder(
            expression,
            _obj,
            this
        );
    }
}
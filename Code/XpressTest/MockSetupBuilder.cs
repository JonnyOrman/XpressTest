using System.Linq.Expressions;
using XpressTest.Narration;

namespace XpressTest;

public class MockSetupBuilder<TSut, TObject, TMock>
    :
        VariableBuilder<TSut, TMock, IMockBuilderChainer<TSut, TObject, TMock>>,
        IMockSetupBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly IFunctionNarrator<TObject> _functionNarrator;

    public MockSetupBuilder(
        TMock mock,
        IArrangementSetter<TMock> mockObjectSetter,
        IMockBuilderChainer<TSut, TObject, TMock> mockObjectBuilderChainer,
        IFunctionNarrator<TObject> functionNarrator
        )
        : base(
            mock,
            mockObjectSetter,
            mockObjectBuilderChainer
        )
    {
        _functionNarrator = functionNarrator;
    }

    public IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    )
    {
        var expression = func.Invoke(null);

        _functionNarrator.Narrate(expression);
        
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
        _functionNarrator.Narrate(expression);
        
        return Chainer.StartMockSetupResultBuilder(
            expression,
            Obj,
            this
        );
    }
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IMockBuilderChainer<TSut, TObject, TMock>
    :
        IVariableBuilderChainer<TSut>
    where TSut : class
{
    IMockSetupResultBuilder<TSut, TObject, TResult> StartMockSetupResultBuilder<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func,
        TMock mock,
        IMockSetupBuilder<TSut, TObject> mockObjectBuilder
    );
    
    IMockSetupResultBuilder<TSut, TObject, TResult> StartMockSetupResultBuilder<TResult>(
        Expression<Func<TObject, TResult>> expression,
        TMock mock,
        IMockSetupBuilder<TSut, TObject> mockObjectBuilder
    );
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IMockBuilderChainer<TSut, TObject, TMock>
    :
        IVariableBuilderChainer<TSut>
    where TSut : class
{
    IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> StartMockSetupResultBuilder<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func,
        TMock mock,
        IMockSetupBuilder<TSut, TObject> mockSetupBuilder
    );

    IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> StartMockSetupResultBuilder<TResult>(
        Expression<Func<TObject, TResult>> expression,
        TMock mock,
        IMockSetupBuilder<TSut, TObject> mockSetupBuilder
    );
}
using System.Linq.Expressions;

namespace XpressTest;

public interface IMockSetupBuilder<TSut, TObject>
    :
        IVariableBuilder<TSut>
{
    IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    );

    IMockResultBuilder<TResult, IMockSetupBuilder<TSut, TObject>> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    );
}
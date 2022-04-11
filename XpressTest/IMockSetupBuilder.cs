using System.Linq.Expressions;

namespace XpressTest;

public interface IMockSetupBuilder<TSut, TObject>
    :
        IVariableBuilder<TSut>
{
    IMockSetupResultBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    );

    IMockSetupResultBuilder<TSut, TObject, TResult> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    );
}
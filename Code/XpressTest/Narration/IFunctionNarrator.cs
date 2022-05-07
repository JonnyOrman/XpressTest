using System.Linq.Expressions;

namespace XpressTest.Narration;

public interface IFunctionNarrator<TObject>
{
    void Narrate<TResult>(
        Expression<Func<TObject, TResult>> expression
        );
}
using System.Linq.Expressions;

namespace XpressTest.Narration;

public interface IActionNarrator<TSut, TResult>
{
    void Narrate(Expression<Func<TSut, TResult>> action);
}
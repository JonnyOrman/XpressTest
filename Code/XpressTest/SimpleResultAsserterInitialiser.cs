using System.Linq.Expressions;
using XpressTest.Narration;

namespace XpressTest;

public static class SimpleResultAsserterInitialiser<TSut>
{
    public static ISimpleResultAsserter<TResult> Initialise<TResult>(
        Expression<Func<TSut, TResult>> func,
        INarrative narrative
    )
    {
        var sut = Activator.CreateInstance<TSut>();

        var resultProvider = new ResultProvider<TSut, TResult>(
            sut,
            func
        );

        var arrangement = ArrangementInitialiser.Initialise();

        Action action = () => resultProvider.Get();

        var exceptionAsserter = new ExceptionAsserter(action);

        var resultNarrator = ResultNarratorInitialiser<TResult>.Initialise(narrative);

        return new SimpleResultAsserter<TSut, TResult>(
            sut,
            arrangement,
            () => resultProvider.Get(),
            exceptionAsserter,
            resultNarrator
            );
    }
}
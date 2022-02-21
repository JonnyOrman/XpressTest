using Xunit;

namespace XpressTest;

public class SimpleTestRunner<TSut, TResult> : ISimpleTestRunner<TSut>
{
    private readonly ISimpleActionExecutor<TSut, TResult> _actionExecutor;
    private readonly TResult _expectedResult;

    public SimpleTestRunner(
        ISimpleActionExecutor<TSut, TResult> actionExecutor,
        TResult expectedResult
        )
    {
        _actionExecutor = actionExecutor;
        _expectedResult = expectedResult;
    }

    public void Run(TSut sut)
    {
        var actualResult = _actionExecutor.Execute(sut);

        Assert.Equal(_expectedResult, actualResult);
    }
}

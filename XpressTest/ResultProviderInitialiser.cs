namespace XpressTest;

public static class ResultProviderInitialiser<TSut, TResult>
{
    public static IResultProvider<TResult> Initialise(Func<TSut, TResult> func)
    {
        var sut = Activator.CreateInstance<TSut>();

        return new ResultProvider<TSut, TResult>(
            sut,
            func
        );
    }
}

namespace XpressTest;

public static class GivenA<TSut, TResult>
    where TSut : class
{
    public static ITestBuilder<Func<TSut, TResult>, Action<TResult>> WithA<TDependency>()
        where TDependency : class
    {
        var builder = new ResultTestBuilder<TSut, TResult>(new List<IDependency>());

        builder.WithA<TDependency>();

        return builder;
    }

    public static ITestBuilder<Func<TSut, TResult>, Action<TResult>> WhenIt(Func<TSut, TResult> func)
    {
        var builder = new ResultTestBuilder<TSut, TResult>(new List<IDependency>());

        builder.WhenIt(func);

        return builder;
    }
}

public static class GivenA<TSut>
    where TSut : class
{
    public static ITestBuilder<Action<TSut>, Action> WithA<TDependency>()
        where TDependency : class
    {
        var builder = new VoidTestBuilder<TSut>(new List<IDependency>());

        builder.WithA<TDependency>();

        return builder;
    }

    public static ITestBuilder<Action<TSut>, Action> With<TDependency>(TDependency dependency)
        where TDependency : class
    {
        var builder = new VoidTestBuilder<TSut>(new List<IDependency>());
        
        builder.With(dependency);

        return builder;
    }

    public static ITestBuilder<Action<TSut>, Action> WhenIt(Action<TSut> func)
    {
        var builder = new VoidTestBuilder<TSut>(new List<IDependency>());

        builder.WhenIt(func);

        return builder;
    }
}
namespace XpressTest;

public class ValueDependencyBuilder<TSut, TDependency>
    :
        Builder<TDependency, IValueDependencyBuilderChainer<TSut>>,
        IValueDependencyBuilder<TSut>
{
    public ValueDependencyBuilder(
        TDependency dependency,
        IObjectSetter<TDependency> valueDependencySetter,
        IValueDependencyBuilderChainer<TSut> valueDependencyBuilderChainer
        )
        : base(
            dependency,
            valueDependencySetter,
            valueDependencyBuilderChainer
        )
    {
    }
    
    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        return Chain(() => _chainer.StartSutAsserter());
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> func)
    {
        return Chain(() => _chainer.StartVoidAsserter(
            func
        ));
    }

    public IMockDependencyBuilder<TSut, TMockDependency> WithA<TMockDependency>()
        where TMockDependency : class
    {
        return Chain(() => _chainer.StartMockDependencyBuilder<TMockDependency>());
    }

    public IMockDependencyBuilder<TSut, TMockDependency> WithA<TMockDependency>(string name)
        where TMockDependency : class
    {
        return Chain(() => _chainer.StartNamedMockDependencyBuilder<TMockDependency>(name));
    }
}
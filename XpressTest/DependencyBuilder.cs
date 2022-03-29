namespace XpressTest;

public class DependencyBuilder<TSut, TDependency>
    :
        Builder<TDependency, IDependencyBuilderChainer<TSut>>,
    IDependencyBuilder<TSut>
    where TSut : class
    where TDependency : class
{
    public DependencyBuilder(
        TDependency dependency,
        IObjectSetter<TDependency> setter,
        IDependencyBuilderChainer<TSut> dependencyBuilderChainer
            )
        : base(
            dependency,
            setter,
            dependencyBuilderChainer
            )
    {
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return Chain(() => _chainer.ComposeDependencyBuilder(
            newDependency
        ));
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return Chain(() => _chainer.ComposeMockDependencyBuilder<TNewDependency>());
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        return Chain(() => _chainer.ComposeAsserter());
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return Chain(() => _chainer.ComposeAsserter(
            action
            ));
    }
}
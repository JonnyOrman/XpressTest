namespace XpressTest;

public class ValueDependencyBuilder<TSut, TDependency>
    :
        IValueDependencyBuilder<TSut>
{
    private readonly TDependency _dependency;
    private readonly ITestComposer<TSut> _testComposer;

    public ValueDependencyBuilder(
        TDependency dependency,
        ITestComposer<TSut> testComposer
        )
    {
        _dependency = dependency;
        _testComposer = testComposer;
    }
    
    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            _testComposer.Arrangement
        );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> func)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            func,
            _testComposer.Arrangement
        );
    }
}
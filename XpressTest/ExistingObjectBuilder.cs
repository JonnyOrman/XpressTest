namespace XpressTest;

public class ExistingObjectBuilder<TSut>
    :
        IExistingObjectBuilder<TSut>
where TSut : class
{
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;

    public ExistingObjectBuilder(
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator
        )
    {
        _voidAsserterCreator = voidAsserterCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return _voidAsserterCreator.Create(
            action
        );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _voidAsserterCreator.Create(
            func
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }
    
    public IExistingObjectBuilder<TSut> With<TNamedObject>(string objectName)
    {
        return _objectBuilderCreator.Create<TNamedObject>(
            objectName
        );
    }

    public IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class
    {
        return _mockDependencyBuilderCreator.CreateExisting<TMock>();
    }

    public void Set(ObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
}
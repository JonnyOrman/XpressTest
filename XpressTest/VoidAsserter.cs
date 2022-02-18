namespace XpressTest;

public class VoidAsserter<TSut> : IAsserter<System.Action<IArrangement>>
    where TSut : class
{
    private readonly System.Action<IAction<TSut>> _action;
    private readonly IDependencyCollection _dependencies;
    private readonly IObjectCollection _objects;

    public VoidAsserter(
        System.Action<IAction<TSut>> action,
        IDependencyCollection dependencies,
        IObjectCollection objects
        )
    {
        _action = action;
        _dependencies = dependencies;
        _objects = objects;
    }
    
    public ITester ThenItShould(System.Action<IArrangement> assertion)
    {
        return new VoidTester<TSut>(
            _action,
            assertion,
            _dependencies,
            _objects
            );
    }
}
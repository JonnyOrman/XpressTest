namespace XpressTest;

public class NamedMockObjectSetter<TObject> : INamedMockObjectSetter<TObject>
    where TObject : class
{
    private readonly IArrangement _arrangement;

    public NamedMockObjectSetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(INamedMock<TObject> namedMock)
    {
        _arrangement.Add(namedMock);
    }
}
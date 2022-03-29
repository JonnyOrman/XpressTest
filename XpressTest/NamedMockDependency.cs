namespace XpressTest;

public class NamedMockDependency<TDependency>
:
    INamedDependency
    where TDependency : class
{
    private readonly INamedMock<TDependency> _namedMock;

    public NamedMockDependency(
        INamedMock<TDependency> namedMock
        )
    {
        _namedMock = namedMock;
    }

    public object Object => _namedMock.Object;
    public string Name => _namedMock.Name;
}
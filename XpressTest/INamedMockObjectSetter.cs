namespace XpressTest;

public interface INamedMockObjectSetter<TObject>
    where TObject : class
{
    void Set(INamedMock<TObject> namedMock);
}
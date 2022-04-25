namespace XpressTest;

public class NamedMockObjectSetter<TObject> :
    ArrangementSetter<INamedMock<TObject>>
    where TObject : class
{
    public NamedMockObjectSetter(
        IArrangement arrangement
    ) : base(
        arrangement,
        (arrangement, namedMock) => arrangement.Add(namedMock)
    )
    {
    }
}
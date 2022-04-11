namespace XpressTest;

public class NamedMockObjectSetter<TObject> :
    ArrangementSetter<INamedMock<TObject>>
    where TObject : class
{
    public NamedMockObjectSetter(
        IArrangement arrangement
    ) : base(
        arrangement,
        (arrangement, mock) => arrangement.Add(mock)
    )
    {
    }
}
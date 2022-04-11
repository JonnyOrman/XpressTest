namespace XpressTest;

public class MockObjectSetter<TObject> :
    ArrangementSetter<IMock<TObject>>
    where TObject : class
{
    public MockObjectSetter(
        IArrangement arrangement
    ) : base(
        arrangement,
        (arrangement, mock) => arrangement.Add(mock)
    )
    {
    }
}
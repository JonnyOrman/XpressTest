using Moq;

namespace XpressTest;

public class MockObjectSetter<TObject> : IMockObjectSetter<TObject>
    where TObject : class
{
    private readonly IArrangement _arrangement;

    public MockObjectSetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(Mock<TObject> mock)
    {
        _arrangement.Add(mock);
    }
}
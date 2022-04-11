namespace XpressTest;

public class MockDependencySetter<TDependency>
    :
        ArrangementSetter<IMock<TDependency>>
where TDependency : class
{
    public MockDependencySetter(
        IArrangement arrangement
        ) : base(
        arrangement,
        (arrangement, mockDependency) =>
        {
            arrangement.Add(mockDependency);
            arrangement.AddDependency(mockDependency.MoqMock.Object);
        }
    )
    {
    }
}
namespace XpressTest;

public class NamedMockDependencySetter<TDependency>
    :
        ArrangementSetter<INamedMock<TDependency>>
where TDependency : class
{
    public NamedMockDependencySetter(
        IArrangement arrangement
        ) : base(
        arrangement,
        (arrangement, namedMockDependency) =>
        {
            arrangement.AddDependency(
                namedMockDependency.Object,
                namedMockDependency.Name
            );

            arrangement.Add(namedMockDependency);
        }
    )
    {
    }
}
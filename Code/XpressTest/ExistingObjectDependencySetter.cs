namespace XpressTest;

public class ExistingObjectDependencySetter<TDependency>
    :
        ArrangementSetter<TDependency>
{
    public ExistingObjectDependencySetter(
        IArrangement arrangement
    )
        :
        base(
            arrangement,
            (arrangement, dependency) =>
            {
                arrangement.AddDependency(dependency);
            }
        )
    {
    }
}
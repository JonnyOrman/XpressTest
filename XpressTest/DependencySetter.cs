namespace XpressTest;

public class DependencySetter<TDependency>
    :
        ArrangementSetter<TDependency>
{
    public DependencySetter(
        IArrangement arrangement
    ) : base(
        arrangement,
        (arrangement, obj) =>
        {
            arrangement.Add(obj);
            arrangement.AddDependency(obj);
        })
    {
    }
}
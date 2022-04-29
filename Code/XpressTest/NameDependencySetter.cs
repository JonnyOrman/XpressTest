namespace XpressTest;

public class NameDependencySetter<TDependency>
    :
        ArrangementSetter<INamedDependency>
{
    public NameDependencySetter(
        IArrangement arrangement
    )
        :
        base(
            arrangement,
            (arrangement, dependency) =>
            {
                arrangement.Dependencies.Add(dependency);

                INamedObject<TDependency> namedObject =
                    new NamedObject<TDependency>((TDependency)dependency.Object, dependency.Name);

                arrangement.Add(namedObject);
            })
    {

    }
}
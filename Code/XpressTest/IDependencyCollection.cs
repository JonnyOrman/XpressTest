namespace XpressTest;

public interface IDependencyCollection
{
    void Add(IDependency dependency);

    void Add(INamedDependency namedDependency);

    bool Any();

    IEnumerable<IDependency> GetAll();
}
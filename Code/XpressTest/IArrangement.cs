namespace XpressTest;

public interface IArrangement
    :
        IReadArrangement
{

    void Add<T>(T obj);

    void Add<T>(INamedObject<T> namedObject);

    void Add<T>(IMock<T> mock)
        where T : class;

    void Add<T>(INamedMock<T> namedMock)
        where T : class;

    void AddDependency<TDependency>(TDependency dependency);

    void AddDependency<TDependency>(TDependency dependency, string name);
}
namespace XpressTest;

public class SutComposer<TSut> : ISutComposer<TSut>
    where TSut : class
{
    private readonly IArrangement _arrangement;

    public SutComposer(IArrangement arrangement)
    {
        _arrangement = arrangement;
    }

    public TSut Compose()
    {
        object sut = null;

        if (_arrangement.Dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in _arrangement.Dependencies.GetAll())
            {
                parameters.Add(dependency.Object);
            }

            sut = Activator.CreateInstance(typeof(TSut), parameters.ToArray());
        }
        else
        {
            sut = Activator.CreateInstance<TSut>();
        }

        var typedSut = sut as TSut;

        return typedSut;
    }
}

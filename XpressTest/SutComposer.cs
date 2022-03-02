namespace XpressTest;

public class SutComposer<TSut> : ISutComposer<TSut>
    where TSut : class
{
    public SutComposer(IArrangement arrangement)
    {
        Arrangement = arrangement;
    }

    public TSut Compose()
    {
        object sut = null;

        if (Arrangement.Dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in Arrangement.Dependencies.GetAll())
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

    public IArrangement Arrangement { get; }
}

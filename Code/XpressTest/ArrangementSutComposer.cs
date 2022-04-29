namespace XpressTest;

public class ArrangementSutComposer<TSut> : ISutComposer<TSut>
    where TSut : class
{
    private readonly IArrangement _arrangement;

    public ArrangementSutComposer(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }

    public TSut Compose()
    {
        if (_arrangement.Dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in _arrangement.Dependencies.GetAll())
            {
                parameters.Add(dependency.Object);
            }

            var sut = Activator.CreateInstance(typeof(TSut), parameters.ToArray());

            var typedSut = sut as TSut;

            if (typedSut == null)
            {
                throw new SutActivationException<TSut>();
            }

            return typedSut;
        }

        return Activator.CreateInstance<TSut>();
    }
}

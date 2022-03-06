namespace XpressTest;

public class SutComposer<TSut> : ISutComposer<TSut>
    where TSut : class
{
    public TSut Compose(
        IArrangement arrangement
        )
    {
        object sut = null;

        if (arrangement.Dependencies.Any())
        {
            var parameters = new List<object>();

            foreach (var dependency in arrangement.Dependencies.GetAll())
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

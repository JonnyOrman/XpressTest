namespace XpressTest;

public static class SutActionInitialiser<TSut>
    where TSut : class
{
    public static ISutPropertyTargeter<TSut> Initialise()
    {
        var sut = Activator.CreateInstance<TSut>();

        var arrangement = ArrangementInitialiser.Initialise();

        var sutArrangement = new SutArrangement<TSut>(
            sut,
            arrangement
        );

        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sutArrangement
            );

        return new SutAsserter<TSut>(
            sutPropertyTargeter
            );
    }
}
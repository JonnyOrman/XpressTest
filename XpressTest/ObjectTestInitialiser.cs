namespace XpressTest;

public static class ObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static IVariableBuilder<TSut> Initialise(TObject obj)
    {
        var arrangement = ArrangementInitialiser.Initialise();
        
        var objectSetter = new ObjectSetter<TObject>(
            arrangement
            );

        return VariableTestInitialiser<TSut, TObject>.Initialise(
            obj,
            arrangement,
            objectSetter
            );
    }
}

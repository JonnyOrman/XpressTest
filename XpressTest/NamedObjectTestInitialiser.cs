namespace XpressTest;

public static class NamedObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static IVariableBuilder<TSut> Initialise(
        TObject obj,
        string objectName
        )
    {
        var namedObject = new NamedObject<TObject>(
            obj,
            objectName
        );
        
        var arrangement = ArrangementInitialiser.Initialise();
        
        var namedObjectSetter = new NamedObjectSetter<TObject>(
            arrangement
            );

        return VariableTestInitialiser<TSut, INamedObject<TObject>>.Initialise(
            namedObject,
            arrangement,
            namedObjectSetter
        );
    }
}

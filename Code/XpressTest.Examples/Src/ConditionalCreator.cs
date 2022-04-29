namespace XpressTest.Examples.Src;

public class ConditionalCreator
{
    private readonly ConditionalCreatorSettings _conditionalCreatorSettings;
    private readonly ICreator _creatorA;
    private readonly ICreator _creatorB;

    public ConditionalCreator(
        ConditionalCreatorSettings conditionalCreatorSettings,
        ICreator creatorA,
        ICreator creatorB)
    {
        _conditionalCreatorSettings = conditionalCreatorSettings;
        _creatorA = creatorA;
        _creatorB = creatorB;
    }

    public Entity Create(EntityParameters entityParameters)
    {
        if (_conditionalCreatorSettings.ReturnA)
        {
            return _creatorA.Create(entityParameters);
        }

        return _creatorB.Create(entityParameters);
    }
}
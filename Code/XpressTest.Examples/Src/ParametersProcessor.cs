namespace XpressTest.Examples.Src;

public class ParametersProcessor
{
    private readonly IValidator _validator;
    private readonly ICreator _creator;

    public ParametersProcessor(
        IValidator validator,
        ICreator creator
    )
    {
        _validator = validator;
        _creator = creator;
    }

    public Entity? Process(EntityParameters entityParameters)
    {
        if (_validator.IsValid(entityParameters))
        {
            return _creator.Create(entityParameters);
        }

        return null;
    }
}
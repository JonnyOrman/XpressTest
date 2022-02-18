namespace XpressTest.Examples.Src;

public class Validator : IValidator
{
    public bool IsValid(EntityParameters entityParameters)
    {
        return !string.IsNullOrWhiteSpace(entityParameters.Name);
    }
}
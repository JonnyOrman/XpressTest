namespace XpressTest.Examples.Src;

public class BuilderItem : IBuilderItem
{
    private readonly string _value;

    public BuilderItem(string value)
    {
        _value = value;
    }

    public string GetValue()
    {
        return _value;
    }
}
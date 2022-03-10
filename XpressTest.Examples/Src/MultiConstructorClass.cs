namespace XpressTest.Examples.Src;

public class MultiConstructorClass
{
    public string Name { get; }
    public int Value { get; }

    public MultiConstructorClass()
    {
    }

    public MultiConstructorClass(string name)
    {
        Name = name;
    }

    public MultiConstructorClass(string name, int value)
    {
        Name = name;
        Value = value;
    }
}
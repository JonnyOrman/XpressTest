namespace XpressTest.Examples.Src;

public interface IBuilder
{
    void Add(IBuilderItem builderItem);

    IBuilder AddAndReturn(IBuilderItem builderItem);

    string Build();
}
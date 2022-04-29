using System.Collections.Generic;
using System.Text;

namespace XpressTest.Examples.Src;

public class Builder : IBuilder
{
    private readonly ICollection<IBuilderItem> _builderItems;

    public Builder()
    {
        _builderItems = new List<IBuilderItem>();
    }

    public void Add(IBuilderItem builderItem)
    {
        _builderItems.Add(builderItem);
    }

    public IBuilder AddAndReturn(IBuilderItem builderItem)
    {
        _builderItems.Add(builderItem);

        return this;
    }

    public string Build()
    {
        var stringBuilder = new StringBuilder();

        foreach (var builderItem in _builderItems)
        {
            stringBuilder.Append(builderItem.GetValue());
        }

        return stringBuilder.ToString();
    }
}
using System;

namespace XpressTest.Examples.Src;

public class Creator : ICreator
{
    public Entity Create(EntityParameters entityParameters)
    {
        return new Entity(
            1,
            entityParameters.Name);
    }

    public Entity CreateWithNameRequired(EntityParameters entityParameters)
    {
        if (entityParameters.Name == null)
        {
            throw new ArgumentNullException();
        }

        return Create(entityParameters);
    }
}
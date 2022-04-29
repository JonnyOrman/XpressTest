namespace XpressTest.Examples.Src;

public class Entity
{
    public Entity(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }

    public string Name { get; }
}
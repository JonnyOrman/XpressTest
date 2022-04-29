using System.Threading.Tasks;

namespace XpressTest.Examples.Src;

public interface ICreatorAsync
{
    Task<Entity> CreateAsync(EntityParameters entityParameters);
}
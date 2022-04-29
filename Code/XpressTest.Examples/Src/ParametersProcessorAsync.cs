using System.Threading.Tasks;

namespace XpressTest.Examples.Src;

public class ParametersProcessorAsync
{
    private readonly IValidator _validator;
    private readonly ICreatorAsync _creatorAsync;

    public ParametersProcessorAsync(
        IValidator validator,
        ICreatorAsync creatorAsync
    )
    {
        _validator = validator;
        _creatorAsync = creatorAsync;
    }

    public async Task<Entity?> Process(EntityParameters entityParameters)
    {
        if (_validator.IsValid(entityParameters))
        {
            return await _creatorAsync.CreateAsync(entityParameters);
        }

        return null;
    }
}
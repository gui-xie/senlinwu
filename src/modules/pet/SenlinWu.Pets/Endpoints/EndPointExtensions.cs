using Microsoft.AspNetCore.Routing;
using Senlin.Mo.Endpoints;

namespace SenlinWu.Pets.Endpoints;

public class EndPointExtensions : IModuleEndPoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPets();
    }
}
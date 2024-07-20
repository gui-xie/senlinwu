using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using SenlinWu.Pets.Application;

namespace SenlinWu.Pets.Endpoints;

internal static class PetEndpoint
{
    public static void MapPets(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("pet", (
                IAddPetService service,
                AddPetDto dto)
            => service.ExecuteAsync(dto, default)
        );
        builder.MapPut("pet", IUpdatePetService.IdHandler);
        builder.MapDelete("pet", IDeletePetService.IdHandler);
    }
}
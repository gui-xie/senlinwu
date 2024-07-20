using System.Reflection;
using Senlin.Mo.Application.Abstractions;
using Senlin.Mo.Domain;
using SenlinWu.Pets.Application;
using SenlinWu.Pets.Domain;
using SenlinWu.Pets.Repository;
using SenlinWu.Pets.Repository.Abstractions;
using SenlinWu.Pets.Validators;

namespace SenlinWu.Pets;

public class PetModule(string connectionString): IModule
{
    public IEnumerable<ServiceRegistration> GetServices()
    {
        var genericRepositories = from x in typeof(Pet).Assembly.GetTypes()
            where x.IsClass && !x.IsAbstract && x.IsAssignableTo(typeof(Entity))
            select new ServiceRegistration(
                typeof(IGenericRepository<>).MakeGenericType(x),
                typeof(GenericRepository<>).MakeGenericType(x));
        return genericRepositories;
    }

    public Assembly[] Assemblies =>
    [
        typeof(AddPetService).Assembly,
        typeof(Pet).Assembly,
        typeof(PetDbContext).Assembly,
        typeof(AddPetDtoValidator).Assembly
    ];
        
    public string LocalizationPath => "L/Pet";

    public string ConnectionString => connectionString;
}
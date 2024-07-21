using Senlin.Mo.Application.Abstractions;
using Senlin.Mo.Domain;
using SenlinWu.Pets.Domain;
using SenlinWu.Pets.Repository;
using SenlinWu.Pets.Repository.Abstractions;

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
        
    public string LocalizationPath => "L/Pet";

    public string ConnectionString => connectionString;
}
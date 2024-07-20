using System.Reflection;
using Senlin.Mo.Repository.Abstractions;
using Senlin.Mo.Repository.EFCore.MySQL;

namespace SenlinWu.Pets.Repository;

public class PetDbContext(ConnectionString<PetDbContext> connectionString, IRepositoryHelper helper)
    : RepositoryDbContext<PetDbContext>(connectionString, helper)
{
    protected override Assembly GetDomainAssembly()
    {
        return typeof(Domain.Pet).Assembly;
    }
}
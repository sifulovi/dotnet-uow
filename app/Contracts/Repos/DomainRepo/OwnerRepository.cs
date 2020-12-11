using app.Contracts.Repos.BaseRepo;
using app.Data;
using app.Entities.Models;

namespace app.Contracts.Repos.DomainRepo
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
using app.Contracts.Repos.BaseRepo;
using app.Data;
using app.Entities.Models;

namespace app.Contracts.Repos.DomainRepo
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
using app.Contracts.Repos.DomainRepo;
using app.Data;

namespace app.Contracts.Repos.WrapperRepo
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAccountRepository Account
        {
            get { return _account ??= new AccountRepository(_repositoryContext); }
        }

        public IOwnerRepository Owner
        {
            get { return _owner ??= new OwnerRepository(_repositoryContext); }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
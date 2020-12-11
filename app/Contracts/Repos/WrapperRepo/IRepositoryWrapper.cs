using app.Contracts.Repos.DomainRepo;

namespace app.Contracts.Repos.WrapperRepo
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }

        public IAccountRepository Account { get; }

        void Save();
    }
}
using UowWebApi.IRepositories;

namespace UowWebApi.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}

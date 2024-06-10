

using Repository.GenericRepository.Abstract;

namespace Repository.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
        IGenericRepository<T> GetGenericRepository<T>() where T : class, new()  ;    
    }
}
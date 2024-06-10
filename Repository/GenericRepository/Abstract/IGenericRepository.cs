using System.Linq.Expressions;

namespace Repository.GenericRepository.Abstract
{
    public interface IGenericRepository<T> where T :class,new()
    {
        Task AddAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> GetList();
        void Update(T entity);

        void Delete(T entity);
    }
}
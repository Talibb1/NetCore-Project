using Microsoft.EntityFrameworkCore;
using Repository.DbContext;
using Repository.GenericRepository.Abstract;
using System.Linq.Expressions;

namespace Repository.GenericRepository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class,new()
    {

        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);

        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);

        }
        public IQueryable<T> GetList()
        {
            return _context.Set<T>().AsQueryable();

        }


    }
}

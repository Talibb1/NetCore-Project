

using Repository.DbContext;
using Repository.GenericRepository.Abstract;
using Repository.GenericRepository.Concrete;
using Repository.UnitOfWork.Abstract;

namespace Repository.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Commit()
        {
             _context.SaveChanges();
        }

        IGenericRepository<T> IUnitOfWork.GetGenericRepository<T>() 
        {
            return new GenericRepository<T>(_context);
        }
    }
}

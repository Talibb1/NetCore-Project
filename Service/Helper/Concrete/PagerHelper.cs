using Repository.DbContext;
using Repository.GenericRepository.Abstract;
using Repository.GenericRepository.Concrete;
using Service.Helper.Abstract;

namespace Service.Helper.Concrete
{
    public class PagerHelper :IPagerHelper
    {
        private readonly AppDbContext _context;

        public PagerHelper(AppDbContext context)
        {
            _context = context;
        }

        IPagingGenericRepositry<T> IPagerHelper.PagingGenericRepositry<T>()
        {
            return new PagingGenericRepositry<T>(_context);
        }
    }
}

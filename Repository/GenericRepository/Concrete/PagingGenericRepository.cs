

using Microsoft.EntityFrameworkCore;
using Repository.DbContext;
using Repository.GenericRepository.Abstract;

namespace Repository.GenericRepository.Concrete
{
    public class PagingGenericRepositry<T> : IPagingGenericRepositry<T> where T : class, new()
    {
        private readonly AppDbContext _context;

        public PagingGenericRepositry(AppDbContext context)
        {
            _context = context;
        }


        public List<T> Paging(int CurrentPageCount, int TotalPage, ref int PagingCount)
        {
            var ListObj = _context.Set<T>().AsNoTracking().ToList();
            IQueryable<T> ActorListQueryable = ListObj.AsQueryable();
            PagingCount = (int)Math.Ceiling((double)ActorListQueryable.Count() / (double)TotalPage);

            List<T> ListVMs = ActorListQueryable.Skip((CurrentPageCount - 1)*TotalPage).Take(TotalPage).ToList();
            return ListVMs;

        }


  

     

    }
}

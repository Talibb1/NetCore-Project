using Repository.GenericRepository.Abstract;


namespace Service.Helper.Abstract
{
    public interface IPagerHelper
    {
        IPagingGenericRepositry<T> PagingGenericRepositry<T>() where T : class, new();
    }
  
}

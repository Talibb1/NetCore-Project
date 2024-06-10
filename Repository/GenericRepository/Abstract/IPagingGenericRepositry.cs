namespace Repository.GenericRepository.Abstract
{
    public interface IPagingGenericRepositry<T> where T : class, new()
    {
        List<T> Paging(int CurrentPageCount, int TotalPage, ref int PagingCount);
    }
}
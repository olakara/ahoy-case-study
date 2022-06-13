namespace Application.Common.Models
{
    public class PaginatedResult
    {
        public IEnumerable<T> Items { get; }
        public int PageIndex {get;}
        public int TotalPages {get;}
        public int TotalCount {get;}

        public PaginatedResult(IEnumerable<T> items, int pageIndex, int totalPages, int totalCount)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            TotalCount = totalCount;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;        
    }
}
namespace CallBoardNix.Models
{
    public class PaginationAdvertModel
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public PaginationAdvertModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(Convert.ToDecimal(count / pageSize));
        }
    }
}

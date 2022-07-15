namespace CallBoardNix.Models
{
    public class PaginationModel
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public PaginationModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(Convert.ToDecimal(count / pageSize));
            int total = TotalPages;
            if((total*pageSize)<count)
            { 
                TotalPages= total+1;
            }
        }
    }
}

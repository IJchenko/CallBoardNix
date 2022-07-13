namespace CallBoardNix.Models
{
    public class ListOfAdvert
    {
        public List<AdvertView>? adverts { get; set;}
        public PaginationAdvertModel? pagination { get; set;}
        public ListOfAdvert(PaginationAdvertModel paginationAdvertModel, List<AdvertView> adverts)
        {
            this.pagination = paginationAdvertModel;
            this.adverts = adverts;
        }
    }
}

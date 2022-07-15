namespace CallBoardNix.Models
{
    public class ListOfAdvert
    {
        public List<AdvertView>? adverts { get; set;}
        public PaginationModel? pagination { get; set;}
        public ListOfAdvert(PaginationModel paginationAdvertModel, List<AdvertView> adverts)
        {
            this.pagination = paginationAdvertModel;
            this.adverts = adverts;
        }
    }
}

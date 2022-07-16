namespace CallBoardNix.Models.Advert
{
    public class AdvertInfoModel
    {
        public AdvertView AdvertView { get; set; }
        public CompanyView CompanyView { get; set; }
        public AdvertInfoModel(AdvertView advertView, CompanyView companyView)
        {
            AdvertView = advertView;
            CompanyView = companyView;
        }
    }
}

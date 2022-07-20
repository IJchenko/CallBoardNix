namespace CallBoardNix.Models.Advert
{
    public class AdvertInfoModel
    {
        public Guid UserIsInCurrent { get; set; }
        public AdvertView AdvertView { get; set; }
        public CompanyView CompanyView { get; set; }
        public AdvertInfoModel(AdvertView advertView, CompanyView companyView, Guid userIsInCurrent)
        {
            AdvertView = advertView;
            CompanyView = companyView;
            UserIsInCurrent = userIsInCurrent;
        }
    }
}

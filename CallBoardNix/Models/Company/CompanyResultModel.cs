namespace CallBoardNix.Models
{
    public class CompanyResultModel
    {
        public UserViewModel User { get; set; }
        public CompanyView Company { get; set; }
        public CompanyResultModel(UserViewModel user, CompanyView company)
        {
            Company = company;
            User = user;
        }
        public CompanyResultModel(UserViewModel user)
        {
            User = user;
        }
    }
}

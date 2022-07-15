namespace CallBoardNix.Models
{
    public class CompanyResultModel
    {
        public UserViewModel User { get; set; }
        public List<CompanyView> Companys { get; set; }
        public CompanyView Company { get; set; }
        public PaginationModel Pagination { get; set; }
        public CompanyResultModel(UserViewModel user, CompanyView company, List<CompanyView> companys, PaginationModel pagination)
        {
            Pagination = pagination;
            Companys = companys;
            Company = company;
            User = user;
        }
        public CompanyResultModel(UserViewModel user, List<CompanyView> companys, PaginationModel pagination)
        {
            Pagination = pagination;
            Companys = companys;
            User = user;
        }
    }
}

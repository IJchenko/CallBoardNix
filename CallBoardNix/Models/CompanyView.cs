using DataLayer.Models;

namespace CallBoardNix.Models
{
    public class CompanyView
    {
        public Guid IdCompanyView { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
    }
}

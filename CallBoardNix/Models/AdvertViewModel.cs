using DataLayer.Models;

namespace CallBoardNix.Models
{
    public class AdvertViewModel
    {
        public string NameAdvert { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Salary { get; set; }
        public Company company { get; set; }
        public Category category { get; set; }
    }
}

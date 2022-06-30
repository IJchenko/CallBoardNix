using DataLayer.Models;

namespace CallBoardNix.Models
{
    public class CompanyView
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<User>? Users { get; set; }
        public string? URLImage { get; set; }
    }
}

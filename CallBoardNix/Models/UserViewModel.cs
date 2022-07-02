using DataLayer.Models;

namespace CallBoardNix.Models
{
    public class UserViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid IdResumes { get; set; }
        public Guid IdCompany { get; set; }
        public Guid Review { get; set; }
    }
}

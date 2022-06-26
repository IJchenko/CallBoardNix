using DataLayer.Models;

namespace CallBoardNix.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Company> Companies { get; set; }
        public List<Review> Reviews { get; set; }
    }
}

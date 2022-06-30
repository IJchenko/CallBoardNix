using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Company> Companies { get; set; }
        public List<Review> Reviews { get; set; }
    }
    public enum StatusType
    {
        Worker,
        Employer
    }
}

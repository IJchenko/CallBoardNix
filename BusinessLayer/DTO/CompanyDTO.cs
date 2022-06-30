using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Review> Reviews { get; set; }
        public List<User> Users { get; set; }
        public string URLImage { get; set; }
    }
}

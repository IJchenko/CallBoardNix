using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Resume
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public Category Category { get; set; }
        public string URLImage { get; set; }
    }
}
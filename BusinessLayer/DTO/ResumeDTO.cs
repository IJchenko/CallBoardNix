using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ResumeDTO
    {
        public Guid IdResume { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdCategory { get; set; }
    }
}

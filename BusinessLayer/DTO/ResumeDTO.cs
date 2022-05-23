using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ResumeDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public string URLImage { get; set; }
    }
}

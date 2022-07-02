using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ReviewDTO
    {
        public Guid IdReview { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdCompany { get; set; }
    }
}

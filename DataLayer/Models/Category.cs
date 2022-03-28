using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string URLImage { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Category
    {
        [Key]
        public Guid IdCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
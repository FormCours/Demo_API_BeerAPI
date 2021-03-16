using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryData
    {
        [Required]
        public string Name { get; set; }
    }
}
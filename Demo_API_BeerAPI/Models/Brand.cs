using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int? CreationYear { get; set; }
    }

    public class BrandData
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int? CreationYear { get; set; }
    }
}
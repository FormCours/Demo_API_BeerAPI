using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string Country { get; set; }
    }

    public class BreweryData
    {
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string Country { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double? Degree { get; set; }
        public Brewery Brewery { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }

    public class BeerData
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double? Degree { get; set; }
        public int IdBrewery { get; set; }
        public int? IdBrand { get; set; }
    }

    public class BeerPartialData
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double? Degree { get; set; }
        public int? IdBrewery { get; set; }
        public int? IdBrand { get; set; }
    }
}
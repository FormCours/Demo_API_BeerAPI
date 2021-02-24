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
        public double Degree { get; set; }
        public string Brewery { get; set; }
        public string Color { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }


}
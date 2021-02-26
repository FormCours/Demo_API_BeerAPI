using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Repository;

namespace Demo_API_BeerAPI.DAL.Entities
{
    public class BeerEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double? Degree { get; set; }

        public int IdBrewery { get; set; }
        public int? IdBrand { get; set; }
    }
}
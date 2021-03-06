﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Repository;

namespace Demo_API_BeerAPI.DAL.Entities
{
    public class BreweryEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string Country { get; set; }
    }
}

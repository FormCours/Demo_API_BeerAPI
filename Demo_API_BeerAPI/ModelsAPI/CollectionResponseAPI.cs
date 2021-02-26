using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ModelsAPI
{
    public class CollectionResponseAPI
    {
        public int Total { get; set; }
        public int NbResult { get { return Results.Count(); } }
        public IEnumerable<object> Results { get; set; }

        public CollectionResponseAPI(int total, IEnumerable<object> data) 
        {
            this.Total = total;
            this.Results = data;
        }
    }
}
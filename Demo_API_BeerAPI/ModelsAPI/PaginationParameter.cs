using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ModelsAPI
{
    public class PaginationParameter
    {
        public int Offset { get; set; }
        public int Limit { get; set; }

        public PaginationParameter()
        {
            Offset = 0;
            Limit = 10;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using
using System.Data.Entity;

namespace BikeSparePartsWebApi.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext():base("BikeSpareDBConStr")
        {
            //empty
        }

        public DbSet<BikeSpareParts> BikeSpares { get; set; }
    }
}
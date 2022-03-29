using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//added
using System.ComponentModel.DataAnnotations;

namespace BikeSparePartsWebApi.Models
{
    public class BikeSpareParts
    {
        [Key]
        public int SparePartID { get; set; }
        [MaxLength(30)]
        public string SparePartName { get; set; }

        public int SparePartPrice { get; set; }

        //for git help
    }
}
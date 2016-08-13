using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supreme_Brands.Models
{
    public class SalesRep
    {
        [Key]
        public int id { set; get; }

        public string userid { set; get; }

        // Foreign key
        public int regionStaffId { set; get; }
        // Navigation property
        public RegionStaff regionStaff { set; get; }

        // Foreign key
        public int profileId { set; get; }
        // Navigation property
        public Profile profile { set; get; }

        public double monthly_target { set; get; }

        public DateTime hiredDate { get; set; }





    }
}
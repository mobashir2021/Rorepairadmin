using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoRepairAdmin.Models
{
    public class customerreviewmodel
    {
        //public int customerreviewsid { get; set; }
        //public Nullable<int> technicianid { get; set; }
        //public string customername { get; set; }
        //public string rating { get; set; }
        //public string monthandyear { get; set; }
        //public string comments { get; set; }
        public tbl_customerreviews tbl { get; set; }

        public string City { get; set; }
    }
}
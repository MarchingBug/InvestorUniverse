using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestorUniverse.Models
{
    public class DataModifierTracker
    {
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }       
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public DataModifierTracker(string cBy, System.DateTime? cOn)
        {
            this.CreatedBy = cBy;
            this.CreatedOn = cOn;
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvestorUniverse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvestorRegion
    {
        public int Id { get; set; }
        public Nullable<int> InvestorId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual Region Region { get; set; }
        public virtual Investor Investor { get; set; }
    }
}

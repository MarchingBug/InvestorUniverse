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
    
    public partial class MeetingFrequency
    {
        public MeetingFrequency()
        {
            this.Investors = new HashSet<Investor>();
        }
    
        public int Id { get; set; }
        public string MeetingFrequency1 { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual ICollection<Investor> Investors { get; set; }
    }
}
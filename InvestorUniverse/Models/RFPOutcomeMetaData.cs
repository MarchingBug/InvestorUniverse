
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class RFPOutcomeMetaData : DateStampMetaData
    {
        public int Id { get; set; }
        [Display(Name="RFP Outcome")]
        public string RFPOutCome1 { get; set; }
      
    }
}
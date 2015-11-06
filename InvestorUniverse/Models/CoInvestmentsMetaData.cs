using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace InvestorUniverse.Models
{
    public class CoInvestmentsMetaData : DateStampMetaData
    {
        public int Id { get; set; }
       
        [Display(Name = "Co-Investments")]
        public string Coinvestments { get; set; }
      
    }
}
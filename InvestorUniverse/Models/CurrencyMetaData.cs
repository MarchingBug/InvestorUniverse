using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class CurrencyMetaData : DateStampMetaData
    {
        public int Id { get; set; }
        [Display(Name="Currency")]
        public string Currency1 { get; set; }
      
    }
}
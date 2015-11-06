using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class SeparateAccountMetaData : DateStampMetaData
    {
        public int Id { get; set; }
        [Display(Name="Separate Account")]        
        public string SeparateAccount1 { get; set; }
    }
}
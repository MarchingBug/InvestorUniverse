using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace InvestorUniverse.Models
{
    public class PriorityMetaData: DateStampMetaData
    {
        [Display(Name="Priority")]
        public string Priority1 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class StageMetaData : DateStampMetaData
    {
        public int Id { get; set; }
        [Display(Name = "Stage")]
        public string Stage1 { get; set; }
    }
}
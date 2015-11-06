using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class TypeMetaData 
    {
       


        public int Id { get; set; }
        [Display(Name = "Type")]
        public string Type1 { get; set; }
    }
}
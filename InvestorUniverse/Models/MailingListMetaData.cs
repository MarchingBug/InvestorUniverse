using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Models
{
    public class MailingListMetaData:DateStampMetaData
    {
        [Display(Name="Mailing List")]
        public string MailingList1 { get; set; }
    }
}
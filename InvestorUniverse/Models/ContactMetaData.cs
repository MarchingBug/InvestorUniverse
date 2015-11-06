using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace InvestorUniverse.Models
{


    public class ContactMetaData : DateStampMetaData
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Investor is Required")]
        public Nullable<int> InvestorId { get; set; }       
      

      
        public Nullable<int> TypeId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "First name")]
        public string Surname { get; set; }

        [Display(Name = "Job Title")]
        public string Job_Title { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
       
        [Phone]
        public string Tel { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> CountryId { get; set; }
         [HiddenInput(DisplayValue = false)]
        public string Country { get; set; }
         [Display(Name = "Zip Code")]
        public Nullable<double> Zip_Code { get; set; }

       
    }
}
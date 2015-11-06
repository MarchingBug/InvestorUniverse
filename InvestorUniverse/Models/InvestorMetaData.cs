using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InvestorUniverse.Models
{
    public class InvestorMetaData
    {



        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "PE Investing")]
        public int? PEInvestingId { get; set; }


        [Display(Name = "Type")]
        public int? TypeId { get; set; }

        [Display(Name = "Region")]
        public int? RegionId { get; set; }


        [Display(Name = "Address")]
        public string Address1 { get; set; }

      
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public double? Zip_Code { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Display(Name = "Website")]
        public string Web { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Telephone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Tel { get; set; }
        [Display(Name = "Fax")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered fax format is not valid.")]
        public string Fax { get; set; }

        [Display(Name = "Funds Under Mgmt Mn")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Funds_under_Mgmt__mn_ { get; set; }
        public int? FundUnderManagementCurrencyId { get; set; }

        [Display(Name = "Funds Under Mgmt Mn USD")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Funds_under_Mgmt__mn_USD_ { get; set; }

        [Display(Name = "Funds Under Mgmt Mn EUR")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Funds_under_Mgmt__mn_EUR_ { get; set; }

        [Display(Name = "Current Allocation to PE")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Current_Allocation_to_PE____ { get; set; }

        [Display(Name = "Current Allocation to PE MN USD")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Current_Allocation_to_PE__mn_USD_ { get; set; }

        [Display(Name = "Current Allocation to PE MN EUR")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Current_Allocation_to_PE__mn_EUR_ { get; set; }

        [Display(Name = "Target Allocation to PE")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Target_Allocation_to_PE____ { get; set; }

        [Display(Name = "Target Allocation to PE MN USD")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Target_Allocation_to_PE__mn_USD_ { get; set; }

        [Display(Name = "Target Allocation to PE MN EUR")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Target_Allocation_to_PE__mn_EUR_ { get; set; }

        [Display(Name = "Separate Accounts Committed Capital")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Separate_Accounts_Committed_Capital___ { get; set; }

        [Display(Name = "Separate Accounts Committed Capital USD")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Separate_Accounts_Committed_Capital_USD_ { get; set; }

        [Display(Name = "Separate Accounts Committed Capital EUR")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Separate_Accounts_Committed_Capital_EUR_ { get; set; }

        [Display(Name = "Typical Investment Size Mn")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Typical_Investment_Size__mn_ { get; set; }

        [Display(Name = "Fund Preferences")]
        public string Fund_Preferences { get; set; }


        [Display(Name = "Geographic Preferences")]
        public string Geographic_Preferences { get; set; }
        public int? FirstTimeId { get; set; }
        public int? FirstCloseId { get; set; }


        [Display(Name = "First Close Investor")]
        public string First_Close_Investor { get; set; }
        public int? SeparateAccountId { get; set; }
        public int? CoInvestmentsId { get; set; }

        [Display(Name = "Co Invest with GP")]
        public string Co_Invest_with_GP { get; set; }
        public int? Next12MonthCurrencyId { get; set; }

        [Display(Name = "Next 12 Months Amount Min Mn")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Amount_min__mn_ { get; set; }

        [Display(Name = "Next 12 Months Amount Max Mn")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Amount_max__mn_ { get; set; }

        [Display(Name = "Next 12 Months Amount Mn Min")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Amount___mn__min { get; set; }

        [Display(Name = "Next 12 Months Amount Mn Max")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Amount___mn__max { get; set; }


        [Display(Name = "Next 12 Months Number of Funds Min")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Number_of_Funds__min_ { get; set; }


        [Display(Name = "Next 12 Months Number of Funds Max")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Next_12_Months_Number_of_Funds__max_ { get; set; }

        [Display(Name = "Next 12 Months Fund Type Preferences")]
        public string Next_12_Months___Fund_Type_Preferences { get; set; }

        [Display(Name = "Date of 12 Month Plan")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Date_of_12_Month_Plan { get; set; }


        [Display(Name = "General Consultants")]
        public string General_Consultants { get; set; }

        [Display(Name = "Private Equity Consultants")]
        public string Private_Equity_Consultants { get; set; }
        public int? Stage { get; set; }

        [Display(Name = "RFP Outcome")]
        public int? RFPOutcome { get; set; }

        [Display(Name = "Abbott Staff")]
        public int? AbbottPerson { get; set; }

        [Display(Name = "Meeting Frequency")]
        public int? MeetingFrequency { get; set; }
        public int? Priority { get; set; }


        [Display(Name = "Abbott Staff")]
        public virtual AbbottPerson AbbottPerson1 { get; set; }

        [Display(Name = "Co-Investment")]
        public virtual Coinvestment Coinvestment { get; set; }

        [Display(Name = "Company Type")]
        public virtual CompanyType CompanyType { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

        [Display(Name = "Company Type")]
        public virtual Country Country { get; set; }

        [Display(Name = "Fund to Fund Currency")]
        public virtual Currency Currency { get; set; }
        [Display(Name = "Next 12 Month Currency")]
        public virtual Currency Currency1 { get; set; }
        public virtual Currency Currency2 { get; set; }
        public virtual Currency Currency3 { get; set; }
        [Display(Name = "First Close")]
        public virtual FirstClose FirstClose { get; set; }

        [Display(Name = "First Time")]
        public virtual FirstTime FirstTime { get; set; }

        [Display(Name = "Investor Industries")]
        public virtual ICollection<InvestorIndustry> InvestorIndustries { get; set; }

        [Display(Name = "Investor Regions")]
        public virtual ICollection<InvestorRegion> InvestorRegions { get; set; }

        [Display(Name = "Meeting Frequency")]
        public virtual MeetingFrequency MeetingFrequency1 { get; set; }

        [Display(Name = "PE Investing")]
        public virtual PEInvesting PEInvesting { get; set; }

        [Display(Name = "Priority")]
        public virtual Priority Priority1 { get; set; }
        public virtual Region Region { get; set; }


        [Display(Name = "RFP OutCome")]
        public virtual RFPOutCome RFPOutCome1 { get; set; }

        [Display(Name = "Separate Account")]
        public virtual SeparateAccount SeparateAccount { get; set; }


        [Display(Name = "Stage")]
        public virtual Stage Stage1 { get; set; }

        // public int Id { get; set; }
        // [Display(Name="Investor")]
        // [Required(ErrorMessage = "Investor is Required")]
        // public string Name { get; set; }
        // [Display(Name = "Name")]
        // public int? PEInvestingId { get; set; }
        // [Display(Name = "Currently Investing in PE")]

        // public int? TypeId { get; set; }
        // [Display(Name = "Type")]
        // [Required(ErrorMessage = "Type is Required")]
        // [HiddenInput(DisplayValue = false)]

        // public int? RegionId { get; set; }
        // [Display(Name = "Type")]
        // [Required(ErrorMessage = "Type is Required")]

        // public string Address { get; set; }
        // [Display(Name = "Address")]
        // public string Address1 { get; set; }
        // [Display(Name = "Address 1")]
        // public string Address2 { get; set; }
        // [Display(Name = "Address 2")]
        // public string City { get; set; }
        // public string State { get; set; }

        // public double? Zip_Code { get; set; }
        // [Display(Name = "Zip code")]
        // public int? CountryId { get; set; }
        // [Display(Name = "Country")]
        // [HiddenInput(DisplayValue = false)]

        // [Url]
        // public string Web { get; set; }

        // [EmailAddress]
        // public string Email { get; set; }
        // [Phone]
        // public string Tel { get; set; }
        // [Phone]
        // public string Fax { get; set; }

        // [Display(Name = "Funds under Mgmt mn")]
        // public double? Funds_under_Mgmt__mn_ { get; set; }

        // [Display(Name = "Funds under Mgmt Curr")]
        // public int? FundUnderManagementCurrencyId { get; set; }
        //[HiddenInput(DisplayValue = false)]

        // public string Funds_under_Mgmt__Curr_ { get; set; }
        // [Display(Name = "Funds under Mgmt Currency")]
        // public double? Funds_under_Mgmt__mn_USD_ { get; set; }
        // [Display(Name = "Funds under Mgmt USD")]

        // public double? Funds_under_Mgmt__mn_EUR_ { get; set; }
        // [Display(Name = "Funds under Mgmt EUR")]
        // public double? Current_Allocation_to_PE____ { get; set; }
        //  [Display(Name = "Current Allocation to PE")]
        // public double? Current_Allocation_to_PE__mn_USD_ { get; set; }
        // [Display(Name = "Current Allocation to PE mn USD")]

        // public double? Current_Allocation_to_PE__mn_EUR_ { get; set; }
        // [Display(Name = "Current Allocation to PE mn EUR")]


        // public string Target_Allocation_to_PE____ { get; set; }
        // [Display(Name = "Target  Allocation to PE")]


        // public string Target_Allocation_to_PE__mn_USD_ { get; set; }
        // [Display(Name = "Target  Allocation to PE  mn USD")]


        // public string Target_Allocation_to_PE__mn_EUR_ { get; set; }
        // [Display(Name = "Target  Allocation to PE mn EUR")]


        // public string Separate_Accounts_Committed_Capital___ { get; set; }
        // [Display(Name = "Separate Accounts Committed_Capital")]


        // public string Separate_Accounts_Committed_Capital_USD_ { get; set; }
        // [Display(Name = "Separate Accounts Committed_Capital USD")]


        // public string Separate_Accounts_Committed_Capital_EUR_ { get; set; }
        // [Display(Name = "Separate Accounts Committed_Capital EUR")]


        // public string Typical_Investment_Size__mn_ { get; set; }
        // [Display(Name = "Typical Investment Size mn")]


        // public string Fund_Preferences { get; set; }
        // [Display(Name = "Fund Preferences")]


        // public string Geographic_Preferences { get; set; }
        // [Display(Name = "Geographic Preferences")]


        // public int? FirstTimeId { get; set; }
        // [Display(Name = "First Time Funds")]

        // public int? FirstCloseId { get; set; }
        // [Display(Name = "First Close Investor")]


        // public string First_Close_Investor { get; set; }

        // [Display(Name = "Separate Accounts")]
        // public int? SeparateAccountId { get; set; }

        // [HiddenInput(DisplayValue = false)]
        // public string Separate_Accounts { get; set; }
        // [Display(Name = "Co Invest with GP")]

        // [HiddenInput(DisplayValue = false)]
        // public int? CoInvestmentsId { get; set; }

        // [HiddenInput(DisplayValue = false)]
        // public string Co_Invest_with_GP { get; set; }

        // [Display(Name = "Next 12 Months Curr")]
        // public int? Next12MonthCurrencyId { get; set; }

        // [HiddenInput(DisplayValue = false)]
        // public string Next_12_Months__Curr_ { get; set; }

        // [Display(Name = "Next 12 Months Curr Amount Min mn")]
        // public double? Next_12_Months_Amount_min__mn_ { get; set; }

        // [Display(Name = "Next 12 Months Amount max  mn")]
        // public double? Next_12_Months_Amount_max__mn_ { get; set; }

        // [Display(Name = "Next 12 Months Amount mn min ")]
        // public double? Next_12_Months_Amount___mn__min { get; set; }

        // [Display(Name = "Next 12 Months Amount mn max ")]
        // public double? Next_12_Months_Amount___mn__max { get; set; }

        // [Display(Name = "Next 12 Months Number of Funds min")]
        // public double? Next_12_Months_Number_of_Funds__min_ { get; set; }

        // [Display(Name = "Next 12 Months Number of Funds max")]       
        // public double? Next_12_Months_Number_of_Funds__max_ { get; set; }

        // [Display(Name = "Next 12 Months Regions")]
        // public string Next_12_Months___Regions { get; set; }

        // [Display(Name = "Next 12 Months Fund Type Preferences")]
        // public string Next_12_Months___Fund_Type_Preferences { get; set; }

        // [Display(Name = "Next 12 Months Industries")]
        // public string Next_12_Months___Industries { get; set; }

        // [Display(Name = "Date of 12 Months Plan")]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        // public Nullable<System.DateTime> Date_of_12_Month_Plan { get; set; }

        // [Display(Name = "General Consultants")]
        // public string General_Consultants { get; set; }

        // [Display(Name = "Private Equity Consultants")]
        // public string Private_Equity_Consultants { get; set; }

        // [Display(Name = "Stage")]
        // public int? Stage { get; set; }

        // [Display(Name = "RFP Outcome")]
        // public int? RFPOutcome { get; set; }

        // [Display(Name = "Abbott Person")]
        // public int? AbbottPerson { get; set; }

        // [Display(Name = "Meeting Frequency")]
        // public int? MeetingFrequency { get; set; }

        // [Display(Name = "Priority")]
        // public int? Priority { get; set; }

        // public virtual AbbottPerson AbbottPerson1 { get; set; }
        // public virtual Coinvestment Coinvestment { get; set; }
        // public virtual ICollection<Contact> Contacts { get; set; }
        // public virtual Country Country1 { get; set; }
        // public virtual Currency Currency { get; set; }
        // public virtual Currency Currency1 { get; set; }
        // public virtual FirstClose FirstClose { get; set; }
        // public virtual FirstTime FirstTime { get; set; }
        // public virtual MeetingFrequency MeetingFrequency1 { get; set; }
        // public virtual PEInvesting PEInvesting { get; set; }
        // public virtual Priority Priority1 { get; set; }
        // public virtual Region Region1 { get; set; }
        // public virtual RFPOutCome RFPOutCome1 { get; set; }
        // public virtual SeparateAccount SeparateAccount { get; set; }
        // public virtual Stage Stage1 { get; set; }
        // public virtual CompanyType CompanyType { get; set; }
    }
}
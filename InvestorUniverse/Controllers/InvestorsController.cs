using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using PagedList;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvestorUniverse.Models;
using System.ComponentModel.DataAnnotations;

namespace InvestorUniverse.Controllers
{
   
    public partial class InvestorsController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: Investors
        public ActionResult Index(string sortOrder,string currentFilter, string searchString,  int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "" : sortOrder;
            ViewBag.sortOrderParam = sortOrder.Contains("desc") ? "" : "desc";
            var sortDirection = sortOrder.Contains("desc") ? "desc" : "";

            var investors = db.Investors.Include(i => i.AbbottPerson1).Include(i => i.Coinvestment).Include(i => i.CompanyType).Include(i => i.Country).Include(i => i.Currency).Include(i => i.Currency1).Include(i => i.Currency2).Include(i => i.Currency3).Include(i => i.FirstClose).Include(i => i.FirstTime).Include(i => i.MeetingFrequency1).Include(i => i.PEInvesting).Include(i => i.Priority1).Include(i => i.Region).Include(i => i.RFPOutCome1).Include(i => i.SeparateAccount).Include(i => i.Stage1);

            if (!String.IsNullOrEmpty(searchString))
            {
                investors = investors.Where(i => i.Name.Contains(searchString)
                                       || i.State.Contains(searchString)
                                       || i.Address1.Contains(searchString)
                                       || i.City.Contains(searchString)
                                       || i.Country.Country1.Contains(searchString)
                                       || i.Currency.Currency1.Contains(searchString)
                                       || i.Email.Contains(searchString));
            }


            var parameter = sortOrder.Replace("desc", "").Trim();
            investors = SortInvestors(sortDirection, investors, parameter);

            int pageSize = 100;
            int pageNumber = (page ?? 1);

            return View(investors.ToPagedList(pageNumber,pageSize));
        }

        private IQueryable<Investor> SortInvestors(string sortDirection, IQueryable<Investor> investors, string parameter)
        {
            switch (sortDirection)
            {
                case "desc":
                    investors = OrderByDescending(parameter, investors);
                    break;
                default:
                    investors = OrderBy(parameter, investors);
                    break;
            }
            return investors;
        }

        public IQueryable<Investor> OrderByDescending(string parameter, IQueryable<Investor> investors )
        {
            switch (parameter.ToLower())
            {
                case "name":
                    investors = investors.OrderByDescending(i => i.Name);
                    break;
                case "state":
                    investors = investors.OrderByDescending(i => i.State);
                    break;
                default:
                    investors = investors.OrderByDescending(i => i.Name);
                    break;
            }

            return investors;
        }

        public IQueryable<Investor> OrderBy(string parameter, IQueryable<Investor> investors)
        {
            switch (parameter.ToLower())
            {
                case "name":
                    investors = investors.OrderBy(i => i.Name);
                    break;
                case "state":
                    investors = investors.OrderBy(i => i.State);
                    break;
                default:
                    investors = investors.OrderBy(i => i.Name);
                    break;
            }

            return investors;
        }

        // GET: Investors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        // GET: Investors/Create
        public ActionResult Create()
        {
            ViewBag.AbbottPerson = new SelectList(db.AbbottPersons, "Id", "AbbottPerson1");
            ViewBag.CoInvestmentsId = new SelectList(db.Coinvestments, "Id", "Coinvestments");
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1");
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1");
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1");
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1");
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1");
            ViewBag.FirstCloseId = new SelectList(db.FirstCloses, "Id", "FirstClose1");
            ViewBag.FirstTimeId = new SelectList(db.FirstTimes, "Id", "FirstTime1");
            ViewBag.MeetingFrequency = new SelectList(db.MeetingFrequencies, "Id", "MeetingFrequency1");
            ViewBag.PEInvestingId = new SelectList(db.PEInvestings, "Id", "PEInvesting1");
            ViewBag.Priority = new SelectList(db.Priorities, "Id", "Priority1");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Region1");
            ViewBag.RFPOutcome = new SelectList(db.RFPOutComes, "Id", "RFPOutCome1");
            ViewBag.SeparateAccountId = new SelectList(db.SeparateAccounts, "Id", "SeparateAccount1");
            ViewBag.Stage = new SelectList(db.Stages, "Id", "Stage1");
            return View();
        }

        // POST: Investors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PEInvestingId,TypeId,RegionId,Address1,Address2,City,State,Zip_Code,CountryId,Web,Email,Tel,Fax,Funds_under_Mgmt__mn_,FundUnderManagementCurrencyId,Funds_under_Mgmt__mn_USD_,Funds_under_Mgmt__mn_EUR_,Current_Allocation_to_PE____,Current_Allocation_to_PE__mn_USD_,Current_Allocation_to_PE__mn_EUR_,Target_Allocation_to_PE____,Target_Allocation_to_PE__mn_USD_,Target_Allocation_to_PE__mn_EUR_,Separate_Accounts_Committed_Capital___,Separate_Accounts_Committed_Capital_USD_,Separate_Accounts_Committed_Capital_EUR_,Typical_Investment_Size__mn_,Fund_Preferences,Geographic_Preferences,FirstTimeId,FirstCloseId,First_Close_Investor,SeparateAccountId,CoInvestmentsId,Co_Invest_with_GP,Next12MonthCurrencyId,Next_12_Months_Amount_min__mn_,Next_12_Months_Amount_max__mn_,Next_12_Months_Amount___mn__min,Next_12_Months_Amount___mn__max,Next_12_Months_Number_of_Funds__min_,Next_12_Months_Number_of_Funds__max_,Next_12_Months___Fund_Type_Preferences,Date_of_12_Month_Plan,General_Consultants,Private_Equity_Consultants,Stage,RFPOutcome,AbbottPerson,MeetingFrequency,Priority")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Investors.Add(investor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AbbottPerson = new SelectList(db.AbbottPersons, "Id", "AbbottPerson1", investor.AbbottPerson);
            ViewBag.CoInvestmentsId = new SelectList(db.Coinvestments, "Id", "Coinvestments", investor.CoInvestmentsId);
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", investor.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", investor.CountryId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FirstCloseId = new SelectList(db.FirstCloses, "Id", "FirstClose1", investor.FirstCloseId);
            ViewBag.FirstTimeId = new SelectList(db.FirstTimes, "Id", "FirstTime1", investor.FirstTimeId);
            ViewBag.MeetingFrequency = new SelectList(db.MeetingFrequencies, "Id", "MeetingFrequency1", investor.MeetingFrequency);
            ViewBag.PEInvestingId = new SelectList(db.PEInvestings, "Id", "PEInvesting1", investor.PEInvestingId);
            ViewBag.Priority = new SelectList(db.Priorities, "Id", "Priority1", investor.Priority);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Region1", investor.RegionId);
            ViewBag.RFPOutcome = new SelectList(db.RFPOutComes, "Id", "RFPOutCome1", investor.RFPOutcome);
            ViewBag.SeparateAccountId = new SelectList(db.SeparateAccounts, "Id", "SeparateAccount1", investor.SeparateAccountId);
            ViewBag.Stage = new SelectList(db.Stages, "Id", "Stage1", investor.Stage);
            return View(investor);
        }

        // GET: Investors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbbottPerson = new SelectList(db.AbbottPersons, "Id", "AbbottPerson1", investor.AbbottPerson);
            ViewBag.CoInvestmentsId = new SelectList(db.Coinvestments, "Id", "Coinvestments", investor.CoInvestmentsId);
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", investor.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", investor.CountryId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FirstCloseId = new SelectList(db.FirstCloses, "Id", "FirstClose1", investor.FirstCloseId);
            ViewBag.FirstTimeId = new SelectList(db.FirstTimes, "Id", "FirstTime1", investor.FirstTimeId);
            ViewBag.MeetingFrequency = new SelectList(db.MeetingFrequencies, "Id", "MeetingFrequency1", investor.MeetingFrequency);
            ViewBag.PEInvestingId = new SelectList(db.PEInvestings, "Id", "PEInvesting1", investor.PEInvestingId);
            ViewBag.Priority = new SelectList(db.Priorities, "Id", "Priority1", investor.Priority);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Region1", investor.RegionId);
            ViewBag.RFPOutcome = new SelectList(db.RFPOutComes, "Id", "RFPOutCome1", investor.RFPOutcome);
            ViewBag.SeparateAccountId = new SelectList(db.SeparateAccounts, "Id", "SeparateAccount1", investor.SeparateAccountId);
            ViewBag.Stage = new SelectList(db.Stages, "Id", "Stage1", investor.Stage);
            return View(investor);
        }

        // POST: Investors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PEInvestingId,TypeId,RegionId,Address1,Address2,City,State,Zip_Code,CountryId,Web,Email,Tel,Fax,Funds_under_Mgmt__mn_,FundUnderManagementCurrencyId,Funds_under_Mgmt__mn_USD_,Funds_under_Mgmt__mn_EUR_,Current_Allocation_to_PE____,Current_Allocation_to_PE__mn_USD_,Current_Allocation_to_PE__mn_EUR_,Target_Allocation_to_PE____,Target_Allocation_to_PE__mn_USD_,Target_Allocation_to_PE__mn_EUR_,Separate_Accounts_Committed_Capital___,Separate_Accounts_Committed_Capital_USD_,Separate_Accounts_Committed_Capital_EUR_,Typical_Investment_Size__mn_,Fund_Preferences,Geographic_Preferences,FirstTimeId,FirstCloseId,First_Close_Investor,SeparateAccountId,CoInvestmentsId,Co_Invest_with_GP,Next12MonthCurrencyId,Next_12_Months_Amount_min__mn_,Next_12_Months_Amount_max__mn_,Next_12_Months_Amount___mn__min,Next_12_Months_Amount___mn__max,Next_12_Months_Number_of_Funds__min_,Next_12_Months_Number_of_Funds__max_,Next_12_Months___Fund_Type_Preferences,Date_of_12_Month_Plan,General_Consultants,Private_Equity_Consultants,Stage,RFPOutcome,AbbottPerson,MeetingFrequency,Priority")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AbbottPerson = new SelectList(db.AbbottPersons, "Id", "AbbottPerson1", investor.AbbottPerson);
            ViewBag.CoInvestmentsId = new SelectList(db.Coinvestments, "Id", "Coinvestments", investor.CoInvestmentsId);
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", investor.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", investor.CountryId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.FundUnderManagementCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.FundUnderManagementCurrencyId);
            ViewBag.Next12MonthCurrencyId = new SelectList(db.Currencies, "Id", "Currency1", investor.Next12MonthCurrencyId);
            ViewBag.FirstCloseId = new SelectList(db.FirstCloses, "Id", "FirstClose1", investor.FirstCloseId);
            ViewBag.FirstTimeId = new SelectList(db.FirstTimes, "Id", "FirstTime1", investor.FirstTimeId);
            ViewBag.MeetingFrequency = new SelectList(db.MeetingFrequencies, "Id", "MeetingFrequency1", investor.MeetingFrequency);
            ViewBag.PEInvestingId = new SelectList(db.PEInvestings, "Id", "PEInvesting1", investor.PEInvestingId);
            ViewBag.Priority = new SelectList(db.Priorities, "Id", "Priority1", investor.Priority);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Region1", investor.RegionId);
            ViewBag.RFPOutcome = new SelectList(db.RFPOutComes, "Id", "RFPOutCome1", investor.RFPOutcome);
            ViewBag.SeparateAccountId = new SelectList(db.SeparateAccounts, "Id", "SeparateAccount1", investor.SeparateAccountId);
            ViewBag.Stage = new SelectList(db.Stages, "Id", "Stage1", investor.Stage);
            return View(investor);
        }

        // GET: Investors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        // POST: Investors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investor investor = db.Investors.Find(id);
            db.Investors.Remove(investor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}

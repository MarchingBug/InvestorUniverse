using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvestorUniverse.Models;
using Microsoft.AspNet.Identity;


namespace InvestorUniverse.Controllers
{
     [Authorize]
    public class CompanyTypeController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /CompanyType/
        public ActionResult Index()
        {
            return View(db.CompanyTypes.ToList());
        }

        // GET: /CompanyType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companytype = db.CompanyTypes.Find(id);
            if (companytype == null)
            {
                return HttpNotFound();
            }
            return View(companytype);
        }

        // GET: /CompanyType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CompanyType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Type")] CompanyType companytype)
        {
            if (ModelState.IsValid)
            {
                companytype.CreatedBy = User.Identity.GetUserName();
                companytype.CreatedOn = DateTime.Now;               
                db.CompanyTypes.Add(companytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companytype);
        }

        // GET: /CompanyType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companytype = db.CompanyTypes.Find(id);
            if (companytype == null)
            {
                return HttpNotFound();
            }
            return View(companytype);
        }

        // POST: /CompanyType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Type")] CompanyType companytype)
        {
            var previous = from a in db.CompanyTypes where a.Id == companytype.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {
                companytype.CreatedBy = creation.CreatedBy;
                companytype.CreatedOn = creation.CreatedOn;
                companytype.ModifiedBy = User.Identity.GetUserName();
                companytype.ModifiedOn = DateTime.Now;
                db.Entry(companytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companytype);
        }

        // GET: /CompanyType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companytype = db.CompanyTypes.Find(id);
            if (companytype == null)
            {
                return HttpNotFound();
            }
            return View(companytype);
        }

        // POST: /CompanyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyType companytype = db.CompanyTypes.Find(id);
            db.CompanyTypes.Remove(companytype);
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

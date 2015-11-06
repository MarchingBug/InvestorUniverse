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
    public class CurrencyController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /Currency/
        public ActionResult Index()
        {
            return View(db.Currencies.ToList());
        }

        // GET: /Currency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // GET: /Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Currency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Currency1")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                currency.CreatedBy = User.Identity.GetUserName();
                currency.CreatedOn = DateTime.Now;      
                db.Currencies.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        // GET: /Currency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: /Currency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Currency1,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] Currency currency)
        {

            var previous = from a in db.Currencies where a.Id == currency.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {

                currency.CreatedBy = creation.CreatedBy;
                currency.CreatedOn = creation.CreatedOn;
                currency.ModifiedBy = User.Identity.GetUserName();
                currency.ModifiedOn = DateTime.Now;
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        // GET: /Currency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: /Currency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Currency currency = db.Currencies.Find(id);
            db.Currencies.Remove(currency);
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

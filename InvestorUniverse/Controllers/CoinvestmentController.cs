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
    public class CoinvestmentController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /Coinvestment/
        public ActionResult Index()
        {
            return View(db.Coinvestments.ToList());
        }

        // GET: /Coinvestment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coinvestment coinvestment = db.Coinvestments.Find(id);
            if (coinvestment == null)
            {
                return HttpNotFound();
            }
            return View(coinvestment);
        }

        // GET: /Coinvestment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Coinvestment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Coinvestment")] Coinvestment coinvestment)
        {

          
            if (ModelState.IsValid)
            {
                coinvestment.CreatedBy = User.Identity.GetUserName();
                coinvestment.CreatedOn = DateTime.Now;                
                db.Coinvestments.Add(coinvestment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coinvestment);
        }

        // GET: /Coinvestment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coinvestment coinvestment = db.Coinvestments.Find(id);
            if (coinvestment == null)
            {
                return HttpNotFound();
            }
            return View(coinvestment);
        }

        // POST: /Coinvestment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Coinvestments")] Coinvestment coinvestment)
        {
            var previous = from a in db.Coinvestments where a.Id == coinvestment.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;


            if (ModelState.IsValid)
            {
                coinvestment.CreatedBy = creation.CreatedBy;
                coinvestment.CreatedOn = creation.CreatedOn;
                coinvestment.ModifiedBy = User.Identity.GetUserName();
                coinvestment.ModifiedOn = DateTime.Now;

                db.Entry(coinvestment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coinvestment);
        }

        // GET: /Coinvestment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coinvestment coinvestment = db.Coinvestments.Find(id);
            if (coinvestment == null)
            {
                return HttpNotFound();
            }
            return View(coinvestment);
        }

        // POST: /Coinvestment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coinvestment coinvestment = db.Coinvestments.Find(id);
            db.Coinvestments.Remove(coinvestment);
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

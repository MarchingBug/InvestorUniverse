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
    public class RFPOutComeController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /RFPOutCome/
        public ActionResult Index()
        {
            return View(db.RFPOutComes.ToList());
        }

        // GET: /RFPOutCome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFPOutCome rfpoutcome = db.RFPOutComes.Find(id);
            if (rfpoutcome == null)
            {
                return HttpNotFound();
            }
            return View(rfpoutcome);
        }

        // GET: /RFPOutCome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /RFPOutCome/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RFPOutCome1")] RFPOutCome rfpoutcome)
        {
            if (ModelState.IsValid)
            {
                rfpoutcome.CreatedBy = User.Identity.GetUserName();
                rfpoutcome.CreatedOn = DateTime.Now;   
                db.RFPOutComes.Add(rfpoutcome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rfpoutcome);
        }

        // GET: /RFPOutCome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFPOutCome rfpoutcome = db.RFPOutComes.Find(id);
            if (rfpoutcome == null)
            {
                return HttpNotFound();
            }
            return View(rfpoutcome);
        }

        // POST: /RFPOutCome/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RFPOutCome1")] RFPOutCome rfpoutcome)
        {

            var previous = from a in db.RFPOutComes where a.Id == rfpoutcome.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;
            if (ModelState.IsValid)
            {

                rfpoutcome.CreatedBy = creation.CreatedBy;
                rfpoutcome.CreatedOn = creation.CreatedOn;
                rfpoutcome.ModifiedBy = User.Identity.GetUserName();
                rfpoutcome.ModifiedOn = DateTime.Now;
                db.Entry(rfpoutcome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rfpoutcome);
        }

        // GET: /RFPOutCome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFPOutCome rfpoutcome = db.RFPOutComes.Find(id);
            if (rfpoutcome == null)
            {
                return HttpNotFound();
            }
            return View(rfpoutcome);
        }

        // POST: /RFPOutCome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RFPOutCome rfpoutcome = db.RFPOutComes.Find(id);
            db.RFPOutComes.Remove(rfpoutcome);
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

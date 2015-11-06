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
    public class RegionController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /Region/
        public ActionResult Index()
        {
            return View(db.Regions.ToList());
        }

        // GET: /Region/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: /Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Region/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Region1")] Region region)
        {
            if (ModelState.IsValid)
            {
                region.CreatedBy = User.Identity.GetUserName();
                region.CreatedOn = DateTime.Now;   
                db.Regions.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(region);
        }

        // GET: /Region/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: /Region/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Region1")] Region region)
        {

            var previous = from a in db.Regions where a.Id == region.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {

                region.CreatedBy = creation.CreatedBy;
                region.CreatedOn = creation.CreatedOn;
                region.ModifiedBy = User.Identity.GetUserName();
                region.ModifiedOn = DateTime.Now;
                db.Entry(region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        // GET: /Region/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: /Region/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = db.Regions.Find(id);
            db.Regions.Remove(region);
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

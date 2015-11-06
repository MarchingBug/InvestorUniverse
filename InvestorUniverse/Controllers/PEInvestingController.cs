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
    public class PEInvestingController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /PEInvesting/
        public ActionResult Index()
        {
            return View(db.PEInvestings.ToList());
        }

        // GET: /PEInvesting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEInvesting peinvesting = db.PEInvestings.Find(id);
            if (peinvesting == null)
            {
                return HttpNotFound();
            }
            return View(peinvesting);
        }

        // GET: /PEInvesting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PEInvesting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PEInvesting1")] PEInvesting peinvesting)
        {
            if (ModelState.IsValid)
            {
                peinvesting.CreatedBy = User.Identity.GetUserName();
                peinvesting.CreatedOn = DateTime.Now;               
                db.PEInvestings.Add(peinvesting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peinvesting);
        }

        // GET: /PEInvesting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEInvesting peinvesting = db.PEInvestings.Find(id);
            if (peinvesting == null)
            {
                return HttpNotFound();
            }
            return View(peinvesting);
        }

        // POST: /PEInvesting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PEInvesting1")] PEInvesting peinvesting)
        {

            var previous = from a in db.PEInvestings where a.Id == peinvesting.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {
                peinvesting.CreatedBy = creation.CreatedBy;
                peinvesting.CreatedOn = creation.CreatedOn;
                peinvesting.ModifiedBy = User.Identity.GetUserName();
                peinvesting.ModifiedOn = DateTime.Now;
                db.Entry(peinvesting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peinvesting);
        }

        // GET: /PEInvesting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEInvesting peinvesting = db.PEInvestings.Find(id);
            if (peinvesting == null)
            {
                return HttpNotFound();
            }
            return View(peinvesting);
        }

        // POST: /PEInvesting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PEInvesting peinvesting = db.PEInvestings.Find(id);
            db.PEInvestings.Remove(peinvesting);
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

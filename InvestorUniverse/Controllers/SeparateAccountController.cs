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
    public class SeparateAccountController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /SeparateAccount/
        public ActionResult Index()
        {
            return View(db.SeparateAccounts.ToList());
        }

        // GET: /SeparateAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeparateAccount separateaccount = db.SeparateAccounts.Find(id);
            if (separateaccount == null)
            {
                return HttpNotFound();
            }
            return View(separateaccount);
        }

        // GET: /SeparateAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SeparateAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SeparateAccount1")] SeparateAccount separateaccount)
        {
            if (ModelState.IsValid)
            {
                separateaccount.CreatedBy = User.Identity.GetUserName();
                separateaccount.CreatedOn = DateTime.Now;  
                db.SeparateAccounts.Add(separateaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(separateaccount);
        }

        // GET: /SeparateAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeparateAccount separateaccount = db.SeparateAccounts.Find(id);
            if (separateaccount == null)
            {
                return HttpNotFound();
            }
            return View(separateaccount);
        }

        // POST: /SeparateAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SeparateAccount1")] SeparateAccount separateaccount)
        {

            var previous = from a in db.SeparateAccounts where a.Id == separateaccount.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {
                separateaccount.CreatedBy = creation.CreatedBy;
                separateaccount.CreatedOn = creation.CreatedOn;
                separateaccount.ModifiedBy = User.Identity.GetUserName();
                separateaccount.ModifiedOn = DateTime.Now;
                db.Entry(separateaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(separateaccount);
        }

        // GET: /SeparateAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeparateAccount separateaccount = db.SeparateAccounts.Find(id);
            if (separateaccount == null)
            {
                return HttpNotFound();
            }
            return View(separateaccount);
        }

        // POST: /SeparateAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeparateAccount separateaccount = db.SeparateAccounts.Find(id);
            db.SeparateAccounts.Remove(separateaccount);
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

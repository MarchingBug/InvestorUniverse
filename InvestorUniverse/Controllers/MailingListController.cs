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
    public class MailingListController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /MailingList/
        public ActionResult Index()
        {
            return View(db.MailingLists.ToList());
        }

        // GET: /MailingList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailinglist = db.MailingLists.Find(id);
            if (mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(mailinglist);
        }

        // GET: /MailingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MailingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MailingList1")] MailingList mailinglist)
        {
            if (ModelState.IsValid)
            {
                mailinglist.CreatedBy = User.Identity.GetUserName();
                mailinglist.CreatedOn = DateTime.Now;      
                db.MailingLists.Add(mailinglist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailinglist);
        }

        // GET: /MailingList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailinglist = db.MailingLists.Find(id);
            if (mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(mailinglist);
        }

        // POST: /MailingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MailingList1,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] MailingList mailinglist)
        {

            var previous = from a in db.MailingLists where a.Id == mailinglist.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {

                mailinglist.CreatedBy = creation.CreatedBy;
                mailinglist.CreatedOn = creation.CreatedOn;
                mailinglist.ModifiedBy = User.Identity.GetUserName();
                mailinglist.ModifiedOn = DateTime.Now;
                db.Entry(mailinglist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailinglist);
        }

        // GET: /MailingList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailinglist = db.MailingLists.Find(id);
            if (mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(mailinglist);
        }

        // POST: /MailingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailingList mailinglist = db.MailingLists.Find(id);
            db.MailingLists.Remove(mailinglist);
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

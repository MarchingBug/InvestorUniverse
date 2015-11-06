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
    public class MarketingFrequencyController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /MarketingFrequency/
        public ActionResult Index()
        {
            return View(db.MeetingFrequencies.ToList());
        }

        // GET: /MarketingFrequency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingFrequency meetingfrequency = db.MeetingFrequencies.Find(id);
            if (meetingfrequency == null)
            {
                return HttpNotFound();
            }
            return View(meetingfrequency);
        }

        // GET: /MarketingFrequency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MarketingFrequency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MeetingFrequency1,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] MeetingFrequency meetingfrequency)
        {
            if (ModelState.IsValid)
            {

                meetingfrequency.CreatedBy = User.Identity.GetUserName();
                meetingfrequency.CreatedOn = DateTime.Now;      
                db.MeetingFrequencies.Add(meetingfrequency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingfrequency);
        }

        // GET: /MarketingFrequency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingFrequency meetingfrequency = db.MeetingFrequencies.Find(id);
            if (meetingfrequency == null)
            {
                return HttpNotFound();
            }
            return View(meetingfrequency);
        }

        // POST: /MarketingFrequency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MeetingFrequency1")] MeetingFrequency meetingfrequency)
        {
            var previous = from a in db.CompanyTypes where a.Id == meetingfrequency.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {

                meetingfrequency.CreatedBy = creation.CreatedBy;
                meetingfrequency.CreatedOn = creation.CreatedOn;
                meetingfrequency.ModifiedBy = User.Identity.GetUserName();
                meetingfrequency.ModifiedOn = DateTime.Now;
                db.Entry(meetingfrequency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingfrequency);
        }

        // GET: /MarketingFrequency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingFrequency meetingfrequency = db.MeetingFrequencies.Find(id);
            if (meetingfrequency == null)
            {
                return HttpNotFound();
            }
            return View(meetingfrequency);
        }

        // POST: /MarketingFrequency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingFrequency meetingfrequency = db.MeetingFrequencies.Find(id);
            db.MeetingFrequencies.Remove(meetingfrequency);
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

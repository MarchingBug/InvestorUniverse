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
    public class AbbottPersonController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /AbbottPerson/
        public ActionResult Index()
        {
            return View(db.AbbottPersons.ToList());
        }

        // GET: /AbbottPerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbottPerson abbottperson = db.AbbottPersons.Find(id);
            if (abbottperson == null)
            {
                return HttpNotFound();
            }
            return View(abbottperson);
        }

        // GET: /AbbottPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AbbottPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AbbottPerson1")] AbbottPerson abbottperson)
        {
            if (ModelState.IsValid)
            {

                abbottperson.CreatedBy = User.Identity.GetUserName();
                abbottperson.CreatedOn = DateTime.Now;
                db.AbbottPersons.Add(abbottperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abbottperson);
        }

        // GET: /AbbottPerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbottPerson abbottperson = db.AbbottPersons.Find(id);
            if (abbottperson == null)
            {
                return HttpNotFound();
            }
            return View(abbottperson);
        }

        // POST: /AbbottPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AbbottPerson1,CreatedBy,CreatedOn")] AbbottPerson abbottperson)
        {
           var previous = from a in db.AbbottPersons where a.Id == abbottperson.Id select a;

           var cOn = previous.Select(s => s.CreatedOn).Single();
           var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(),DateTime.Parse(cOn.ToString()) );

            previous = null;

            if (ModelState.IsValid)
            {
                abbottperson.CreatedBy = creation.CreatedBy;
                abbottperson.CreatedOn = creation.CreatedOn;
                abbottperson.ModifiedBy = User.Identity.GetUserName();
                abbottperson.ModifiedOn = DateTime.Now;
                db.Entry(abbottperson).State = EntityState.Modified;               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abbottperson);
        }

        // GET: /AbbottPerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbottPerson abbottperson = db.AbbottPersons.Find(id);
            if (abbottperson == null)
            {
                return HttpNotFound();
            }
            return View(abbottperson);
        }

        // POST: /AbbottPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbbottPerson abbottperson = db.AbbottPersons.Find(id);
            db.AbbottPersons.Remove(abbottperson);
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

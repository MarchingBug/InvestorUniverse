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
    public class StageController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /Stage/
        public ActionResult Index()
        {
            return View(db.Stages.ToList());
        }

        // GET: /Stage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // GET: /Stage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Stage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Stage1")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                stage.CreatedBy = User.Identity.GetUserName();
                stage.CreatedOn = DateTime.Now;  
                db.Stages.Add(stage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stage);
        }

        // GET: /Stage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: /Stage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Stage1")] Stage stage)
        {

            var previous = from a in db.Stages where a.Id == stage.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {

                stage.CreatedBy = creation.CreatedBy;
                stage.CreatedOn = creation.CreatedOn;
                stage.ModifiedBy = User.Identity.GetUserName();
                stage.ModifiedOn = DateTime.Now;
                db.Entry(stage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stage);
        }

        // GET: /Stage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: /Stage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stage stage = db.Stages.Find(id);
            db.Stages.Remove(stage);
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

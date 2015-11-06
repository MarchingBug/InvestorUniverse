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
    public class ProductListController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: /ProductList/
        public ActionResult Index()
        {
            return View(db.ProductLists.ToList());
        }

        // GET: /ProductList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productlist = db.ProductLists.Find(id);
            if (productlist == null)
            {
                return HttpNotFound();
            }
            return View(productlist);
        }

        // GET: /ProductList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProductList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductList1")] ProductList productlist)
        {
            if (ModelState.IsValid)
            {

                productlist.CreatedBy = User.Identity.GetUserName();
                productlist.CreatedOn = DateTime.Now;   
                db.ProductLists.Add(productlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productlist);
        }

        // GET: /ProductList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productlist = db.ProductLists.Find(id);
            if (productlist == null)
            {
                return HttpNotFound();
            }
            return View(productlist);
        }

        // POST: /ProductList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductList1")] ProductList productlist)
        {

            var previous = from a in db.ProductLists where a.Id == productlist.Id select a;

            var cOn = previous.Select(s => s.CreatedOn).Single();
            var cBy = previous.Select(s => s.CreatedBy).Single();

            DataModifierTracker creation = new DataModifierTracker(cBy.ToString(), DateTime.Parse(cOn.ToString()));

            previous = null;

            if (ModelState.IsValid)
            {
                productlist.CreatedBy = creation.CreatedBy;
                productlist.CreatedOn = creation.CreatedOn;
                productlist.ModifiedBy = User.Identity.GetUserName();
                productlist.ModifiedOn = DateTime.Now;
                db.Entry(productlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productlist);
        }

        // GET: /ProductList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productlist = db.ProductLists.Find(id);
            if (productlist == null)
            {
                return HttpNotFound();
            }
            return View(productlist);
        }

        // POST: /ProductList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductList productlist = db.ProductLists.Find(id);
            db.ProductLists.Remove(productlist);
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

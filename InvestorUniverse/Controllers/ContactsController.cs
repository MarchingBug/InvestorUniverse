using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvestorUniverse.Models;

namespace InvestorUniverse.Controllers
{
    public class ContactsController : Controller
    {
        private MarketingEntities db = new MarketingEntities();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var contacts = db.Contacts.Include(c => c.CompanyType).Include(c => c.Country1).Include(c => c.Investor1);
            return View(await contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1");
            ViewBag.InvestorId = new SelectList(db.Investors, "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContactId,InvestorId,TypeId,Title,Firstname,Surname,Job_Title,Email,Tel,Address1,Address2,City,State,CountryId,Zip_Code,Investor,Country")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", contact.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", contact.CountryId);
            ViewBag.InvestorId = new SelectList(db.Investors, "Id", "Name", contact.InvestorId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", contact.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", contact.CountryId);
            ViewBag.InvestorId = new SelectList(db.Investors, "Id", "Name", contact.InvestorId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContactId,InvestorId,TypeId,Title,Firstname,Surname,Job_Title,Email,Tel,Address1,Address2,City,State,CountryId,Zip_Code,Investor,Country")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TypeId = new SelectList(db.CompanyTypes, "Id", "Type", contact.TypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Country1", contact.CountryId);
            ViewBag.InvestorId = new SelectList(db.Investors, "Id", "Name", contact.InvestorId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public PartialViewResult _GetForInvestors(int investorId)
        {
            ViewBag.InvestorId = investorId;
            List<Contact> contacts = db.Contacts.Where(c => c.Investor1.Id == investorId).ToList();


            return PartialView("_GetForInvestors", contacts);
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

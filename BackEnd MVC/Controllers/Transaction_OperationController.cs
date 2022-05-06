using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORM;

namespace BackEnd_MVC.Controllers
{
    public class Transaction_OperationController : Controller
    {
        private Model1 db = new Model1();

        // GET: Transaction_Operation
        public async Task<ActionResult> Index()
        {
            var transaction_Operation = db.Transaction_Operation.Include(t => t.Compte);
            return View(await transaction_Operation.ToListAsync());
        }

        // GET: Transaction_Operation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Operation transaction_Operation = await db.Transaction_Operation.FindAsync(id);
            if (transaction_Operation == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Operation);
        }

        // GET: Transaction_Operation/Create
        public ActionResult Create()
        {
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle");
            return View();
        }

        // POST: Transaction_Operation/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTransaction,Type,DateTransaction,Montant,IdCompte")] Transaction_Operation transaction_Operation)
        {
            if (ModelState.IsValid)
            {
                db.Transaction_Operation.Add(transaction_Operation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", transaction_Operation.IdCompte);
            return View(transaction_Operation);
        }

        // GET: Transaction_Operation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Operation transaction_Operation = await db.Transaction_Operation.FindAsync(id);
            if (transaction_Operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", transaction_Operation.IdCompte);
            return View(transaction_Operation);
        }

        // POST: Transaction_Operation/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTransaction,Type,DateTransaction,Montant,IdCompte")] Transaction_Operation transaction_Operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction_Operation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", transaction_Operation.IdCompte);
            return View(transaction_Operation);
        }

        // GET: Transaction_Operation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Operation transaction_Operation = await db.Transaction_Operation.FindAsync(id);
            if (transaction_Operation == null)
            {
                return HttpNotFound();
            }
            return View(transaction_Operation);
        }

        // POST: Transaction_Operation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction_Operation transaction_Operation = await db.Transaction_Operation.FindAsync(id);
            db.Transaction_Operation.Remove(transaction_Operation);
            await db.SaveChangesAsync();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test3.Data;
using test3.Models;

namespace test3.Controllers
{
    public class Categorii_de_bileteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Categorii_de_bileteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorii_de_bilete
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorii_de_bilete.ToListAsync());
        }

        // GET: Categorii_de_bilete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sql = "SELECT * FROM Categorii_de_bilete WHERE Categorie_bilet_ID = {0}";
            var categorii_de_bilete = await _context.Categorii_de_bilete.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (categorii_de_bilete == null)
            {
                return NotFound();
            }

            return View(categorii_de_bilete);
        }

        // GET: Categorii_de_bilete/Create
        public IActionResult Create()
        {
            ViewBag.DenumireList = new SelectList(new[] { "Bilet standard", "Bilet copil", "Bilet student" });
            return View();
        }

        // POST: Categorii_de_bilete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categorie_bilet_ID,Denumire,Pret")] Categorii_de_bilete categorii_de_bilete)
        {
            if (ModelState.IsValid)
            {

                var sql = $"INSERT INTO Categorii_de_bilete (Denumire, Pret) VALUES " +
                          $"('{categorii_de_bilete.Denumire}', {categorii_de_bilete.Pret})";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(categorii_de_bilete);
        }

        // GET: Categorii_de_bilete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /* var categorii_de_bilete = await _context.Categorii_de_bilete.FindAsync(id);*/
            var sql = "SELECT * FROM Categorii_de_bilete WHERE Categorie_bilet_ID = {0}";
            var categorii_de_bilete = await _context.Categorii_de_bilete.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (categorii_de_bilete == null)
            {
                return NotFound();
            }
            return View(categorii_de_bilete);
        }

        // POST: Categorii_de_bilete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Categorie_bilet_ID,Denumire,Pret")] Categorii_de_bilete categorii_de_bilete)
        {
            if (id != categorii_de_bilete.Categorie_bilet_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sql = $"UPDATE Categorii_de_bilete SET Denumire = '{categorii_de_bilete.Denumire}', " +
                          $"Pret = {categorii_de_bilete.Pret} WHERE Categorie_bilet_ID = {categorii_de_bilete.Categorie_bilet_ID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(categorii_de_bilete);
        }

        // GET: Categorii_de_bilete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

   
            var sql = "SELECT * FROM Categorii_de_bilete WHERE Categorie_bilet_ID = {0}";
            var categorii_de_bilete = await _context.Categorii_de_bilete.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (categorii_de_bilete == null)
            {
                return NotFound();
            }

            return View(categorii_de_bilete);
        }

        // POST: Categorii_de_bilete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var sql = $"DELETE FROM Categorii_de_bilete WHERE Categorie_bilet_ID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool Categorii_de_bileteExists(int id)
        {
            return _context.Categorii_de_bilete.Any(e => e.Categorie_bilet_ID == id);
        }
    }
}

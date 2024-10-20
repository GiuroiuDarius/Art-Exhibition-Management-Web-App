using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using test3.Data;
using test3.Models;

namespace test3.Controllers
{
    public class Categorii_de_exponateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Categorii_de_exponateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorii_de_exponate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorii_de_exponate.ToListAsync());
        }

        // GET: Categorii_de_exponate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii_de_exponate = await _context.Categorii_de_exponate
                .FirstOrDefaultAsync(m => m.CategorieID == id);
            if (categorii_de_exponate == null)
            {
                return NotFound();
            }

            return View(categorii_de_exponate);
        }

        // GET: Categorii_de_exponate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorii_de_exponate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieID,Tipul_de_exponat")] Categorii_de_exponate categorii_de_exponate)
        {
            if (ModelState.IsValid)
            {

                var sql = "INSERT INTO Categorii_de_exponate (Tipul_de_exponat) VALUES (@Tipul_de_exponat)";
                await _context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@Tipul_de_exponat", categorii_de_exponate.Tipul_de_exponat));
                return RedirectToAction(nameof(Index));
            }
            return View(categorii_de_exponate);
        }

        // GET: Categorii_de_exponate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii_de_exponate = await _context.Categorii_de_exponate.FindAsync(id);
            if (categorii_de_exponate == null)
            {
                return NotFound();
            }
            return View(categorii_de_exponate);
        }

        // POST: Categorii_de_exponate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieID,Tipul_de_exponat")] Categorii_de_exponate categorii_de_exponate)
        {
            if (id != categorii_de_exponate.CategorieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sql = $"UPDATE Categorii_de_exponate SET Tipul_de_exponat = '{categorii_de_exponate.Tipul_de_exponat}' " +
                          $"WHERE CategorieID = {categorii_de_exponate.CategorieID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(categorii_de_exponate);
        }

        // GET: Categorii_de_exponate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii_de_exponate = await _context.Categorii_de_exponate
                .FirstOrDefaultAsync(m => m.CategorieID == id);
            if (categorii_de_exponate == null)
            {
                return NotFound();
            }

            return View(categorii_de_exponate);
        }

        // POST: Categorii_de_exponate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sql = $"DELETE FROM Categorii_de_exponate WHERE CategorieID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool Categorii_de_exponateExists(int id)
        {
            return _context.Categorii_de_exponate.Any(e => e.CategorieID == id);
        }
    }
}

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
    public class VizitatoriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VizitatoriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vizitatori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vizitatori.ToListAsync());
        }

        // GET: Vizitatori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizitatori = await _context.Vizitatori
                .FirstOrDefaultAsync(m => m.VizitatorID == id);
            if (vizitatori == null)
            {
                return NotFound();
            }

            return View(vizitatori);
        }

        // GET: Vizitatori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vizitatori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VizitatorID,Nume,Prenume,CNP,E_mail,NrTelefon")] Vizitatori vizitatori)
        {
            if (ModelState.IsValid)
            {
                var sql = $"INSERT INTO Vizitatori (Nume, Prenume, CNP, E_mail, NrTelefon) VALUES " +
                          $"('{vizitatori.Nume}', '{vizitatori.Prenume}', '{vizitatori.CNP}', '{vizitatori.E_mail}', '{vizitatori.NrTelefon}')";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(vizitatori);
        }

        // GET: Vizitatori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizitatori = await _context.Vizitatori.FindAsync(id);
            if (vizitatori == null)
            {
                return NotFound();
            }
            return View(vizitatori);
        }

        // POST: Vizitatori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VizitatorID,Nume,Prenume,CNP,E_mail,NrTelefon")] Vizitatori vizitatori)
        {
            if (id != vizitatori.VizitatorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sql = $"UPDATE Vizitatori SET Nume = '{vizitatori.Nume}', Prenume = '{vizitatori.Prenume}', " +
                          $"CNP = '{vizitatori.CNP}', E_mail = '{vizitatori.E_mail}', NrTelefon = '{vizitatori.NrTelefon}' " +
                          $"WHERE VizitatorID = {vizitatori.VizitatorID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(vizitatori);
        }

        // GET: Vizitatori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizitatori = await _context.Vizitatori
                .FirstOrDefaultAsync(m => m.VizitatorID == id);
            if (vizitatori == null)
            {
                return NotFound();
            }

            return View(vizitatori);
        }

        // POST: Vizitatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var sql = $"DELETE FROM Vizitatori WHERE VizitatorID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool VizitatoriExists(int id)
        {
            return _context.Vizitatori.Any(e => e.VizitatorID == id);
        }
    }
}

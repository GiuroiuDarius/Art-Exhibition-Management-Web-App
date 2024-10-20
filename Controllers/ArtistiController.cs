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
    public class ArtistiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artisti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artisti.ToListAsync());
        }

        // GET: Artisti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sql = "SELECT * FROM Artisti WHERE ArtistID = {0}";
            var artisti = await _context.Artisti.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (artisti == null)
            {
                return NotFound();
            }

            return View(artisti);
        }

        // GET: Artisti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artisti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistID,Nume,Prenume,CNP,E_mail,NrTelefon")] Artisti artisti)
        {
            
            if (ModelState.IsValid)
            {
                var sql = $"INSERT INTO Artisti (Nume, Prenume, CNP, E_mail, NrTelefon) VALUES " +
                          $"('{artisti.Nume}', '{artisti.Prenume}', '{artisti.CNP}', '{artisti.E_mail}', '{artisti.NrTelefon}')";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }

            return View(artisti);
        }

        // GET: Artisti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var sql = "SELECT * FROM Artisti WHERE ArtistID = {0}";
            var artisti = await _context.Artisti.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (artisti == null)
            {
                return NotFound();
            }
            return View(artisti);
        }

        // POST: Artisti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistID,Nume,Prenume,CNP,E_mail,NrTelefon")] Artisti artisti)
        {
            if (id != artisti.ArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                var sql = $"UPDATE Artisti SET Nume = '{artisti.Nume}', Prenume = '{artisti.Prenume}', " +
                          $"CNP = '{artisti.CNP}', E_mail = '{artisti.E_mail}', NrTelefon = '{artisti.NrTelefon}' " +
                          $"WHERE ArtistID = {artisti.ArtistID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(artisti);
        }

        // GET: Artisti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var sql = "SELECT * FROM Artisti WHERE ArtistID = {0}";
            var artisti = await _context.Artisti.FromSqlRaw(sql, id).FirstOrDefaultAsync();

            if (artisti == null)
            {
                return NotFound();
            }

            return View(artisti);
        }

        // POST: Artisti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sql = $"DELETE FROM Artisti WHERE ArtistID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistiExists(int id)
        {
            return _context.Artisti.Any(e => e.ArtistID == id);
        }
    }
}

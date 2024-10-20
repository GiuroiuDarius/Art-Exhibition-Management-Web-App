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
    public class ArtistExpozitieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistExpozitieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtistExpozitie
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtistExpozitie.ToListAsync());
        }

        // GET: ArtistExpozitie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistExpozitie = await _context.ArtistExpozitie
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (artistExpozitie == null)
            {
                return NotFound();
            }

            return View(artistExpozitie);
        }

        // GET: ArtistExpozitie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtistExpozitie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistID,ExpozitieID")] ArtistExpozitie artistExpozitie)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(artistExpozitie);
                await _context.SaveChangesAsync();*/
                var sql = $"INSERT INTO ArtistExpozitie (ArtistID, ExpozitieID) VALUES " +
                          $"({artistExpozitie.ArtistID}, {artistExpozitie.ExpozitieID})";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(artistExpozitie);
        }

        // GET: ArtistExpozitie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistExpozitie = await _context.ArtistExpozitie.FindAsync(id);
            if (artistExpozitie == null)
            {
                return NotFound();
            }
            return View(artistExpozitie);
        }

        // POST: ArtistExpozitie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistID,ExpozitieID")] ArtistExpozitie artistExpozitie)
        {
            if (id != artistExpozitie.ArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sql = $"UPDATE ArtistExpozitie SET ExpozitieID = {artistExpozitie.ExpozitieID} " +
                          $"WHERE ArtistID = {artistExpozitie.ArtistID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(artistExpozitie);
        }

        // GET: ArtistExpozitie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistExpozitie = await _context.ArtistExpozitie
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (artistExpozitie == null)
            {
                return NotFound();
            }

            return View(artistExpozitie);
        }

        // POST: ArtistExpozitie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sql = $"DELETE FROM ArtistExpozitie WHERE ArtistID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExpozitieExists(int id)
        {
            return _context.ArtistExpozitie.Any(e => e.ArtistID == id);
        }
    }
}

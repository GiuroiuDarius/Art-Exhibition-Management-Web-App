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
    public class ExpozitiiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpozitiiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expozitii
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expozitii.ToListAsync());
        }

        // GET: Expozitii/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm1()
        {
            return View();
        }

        // POST: Expozitii/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Expozitii.Where(j => j.Nume_expozitie.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Expozitii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitii = await _context.Expozitii
                .FirstOrDefaultAsync(m => m.ExpozitieID == id);
            if (expozitii == null)
            {
                return NotFound();
            }

            return View(expozitii);
        }

        // GET: Expozitii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expozitii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpozitieID,Nume_expozitie,Numar_exponate,Numar_vizitatori,Tema_expozitiei,Data_inceperii,Data_incheierii,Locatie")] Expozitii expozitii)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(expozitii);
                await _context.SaveChangesAsync();*/
                var sql = $"INSERT INTO Expozitii (Nume_expozitie, Numar_exponate, Numar_vizitatori, Tema_expozitiei, Data_inceperii, Data_incheierii, Locatie) VALUES " +
                          $"('{expozitii.Nume_expozitie}', {expozitii.Numar_exponate}, {expozitii.Numar_vizitatori}, '{expozitii.Tema_expozitiei}', " +
                          $"'{expozitii.Data_inceperii}', '{expozitii.Data_incheierii}', '{expozitii.Locatie}')";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(expozitii);
        }

        // GET: Expozitii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitii = await _context.Expozitii.FindAsync(id);
            if (expozitii == null)
            {
                return NotFound();
            }
            return View(expozitii);
        }

        // POST: Expozitii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpozitieID,Nume_expozitie,Numar_exponate,Numar_vizitatori,Tema_expozitiei,Data_inceperii,Data_incheierii,Locatie")] Expozitii expozitii)
        {
            if (id != expozitii.ExpozitieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                /*try
                {
                    _context.Update(expozitii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpozitiiExists(expozitii.ExpozitieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }*/
                var sql = $"UPDATE Expozitii SET Nume_expozitie = '{expozitii.Nume_expozitie}', Numar_exponate = {expozitii.Numar_exponate}, " +
                          $"Numar_vizitatori = {expozitii.Numar_vizitatori}, Tema_expozitiei = '{expozitii.Tema_expozitiei}', " +
                          $"Data_inceperii = '{expozitii.Data_inceperii}', Data_incheierii = '{expozitii.Data_incheierii}', " +
                          $"Locatie = '{expozitii.Locatie}' WHERE ExpozitieID = {expozitii.ExpozitieID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(expozitii);
        }

        // GET: Expozitii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitii = await _context.Expozitii
                .FirstOrDefaultAsync(m => m.ExpozitieID == id);
            if (expozitii == null)
            {
                return NotFound();
            }

            return View(expozitii);
        }

        // POST: Expozitii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var expozitii = await _context.Expozitii.FindAsync(id);
            if (expozitii != null)
            {
                _context.Expozitii.Remove(expozitii);
            }
            await _context.SaveChangesAsync();
            */
            var sql = $"DELETE FROM Expozitii WHERE ExpozitieID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);

            
            return RedirectToAction(nameof(Index));
        }

        private bool ExpozitiiExists(int id)
        {
            return _context.Expozitii.Any(e => e.ExpozitieID == id);
        }
    }
}

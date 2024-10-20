using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test3.Data;
using test3.Models;

namespace test3.Controllers
{
    public class ExpozitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpozitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expozities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expozitie.ToListAsync());
        }

        // GET: Expozities/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Expozities/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Expozitie.Where(j => j.NumeExpozitie.Contains(SearchPhrase)).ToListAsync());
        }


        // GET: Expozities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitie = await _context.Expozitie
                .FirstOrDefaultAsync(m => m.ExpozitieID == id);
            if (expozitie == null)
            {
                return NotFound();
            }

            return View(expozitie);
        }

        // GET: Expozities/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expozities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpozitieID,NumeExpozitie,TemaExpozitiei,DataInceperii,DataFinalizarii,Locatie")] Expozitie expozitie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expozitie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expozitie);
        }

        // GET: Expozities/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitie = await _context.Expozitie.FindAsync(id);
            if (expozitie == null)
            {
                return NotFound();
            }
            return View(expozitie);
        }

        // POST: Expozities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpozitieID,NumeExpozitie,TemaExpozitiei,DataInceperii,DataFinalizarii,Locatie")] Expozitie expozitie)
        {
            if (id != expozitie.ExpozitieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expozitie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpozitieExists(expozitie.ExpozitieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expozitie);
        }

        // GET: Expozities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expozitie = await _context.Expozitie
                .FirstOrDefaultAsync(m => m.ExpozitieID == id);
            if (expozitie == null)
            {
                return NotFound();
            }

            return View(expozitie);
        }

        // POST: Expozities/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expozitie = await _context.Expozitie.FindAsync(id);
            if (expozitie != null)
            {
                _context.Expozitie.Remove(expozitie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpozitieExists(int id)
        {
            return _context.Expozitie.Any(e => e.ExpozitieID == id);
        }
    }
}

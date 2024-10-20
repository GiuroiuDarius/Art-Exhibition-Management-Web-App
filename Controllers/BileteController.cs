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
    public class BileteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BileteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bilete
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bilete.ToListAsync());
        }

        // GET: Bilete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilete = await _context.Bilete
                .FirstOrDefaultAsync(m => m.BiletID == id);
            if (bilete == null)
            {
                return NotFound();
            }

            return View(bilete);
        }



        // GET: Bilete/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bilete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiletID,Data_achizitionarii,Valabilitate,ExpozitieID,VizitatorID,Categorie_bilet_ID")] Bilete bilete)
        {
            if (ModelState.IsValid)
            {

                var sql = "INSERT INTO Bilete (Data_achizitionarii, Valabilitate, ExpozitieID, VizitatorID, Categorie_bilet_ID) VALUES " +
                          "(@Data_achizitionarii, @Valabilitate, @ExpozitieID, @VizitatorID, @Categorie_bilet_ID)";

                await _context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Data_achizitionarii", bilete.Data_achizitionarii),
                    new SqlParameter("@Valabilitate", bilete.Valabilitate),
                    new SqlParameter("@ExpozitieID", bilete.ExpozitieID),
                    new SqlParameter("@VizitatorID", bilete.VizitatorID),
                    new SqlParameter("@Categorie_bilet_ID", bilete.Categorie_bilet_ID));
                return RedirectToAction(nameof(Index));
            }
            return View(bilete);
        }

        // GET: Bilete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilete = await _context.Bilete.FindAsync(id);
            if (bilete == null)
            {
                return NotFound();
            }
            return View(bilete);
        }

        // POST: Bilete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiletID,Data_achizitionarii,Valabilitate,ExpozitieID,VizitatorID,Categorie_bilet_ID")] Bilete bilete)
        {
            if (id != bilete.BiletID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                var sql = $"UPDATE Bilete SET Data_achizitionarii = '{bilete.Data_achizitionarii}', Valabilitate = '{bilete.Valabilitate}', " +
                          $"ExpozitieID = {bilete.ExpozitieID}, VizitatorID = {bilete.VizitatorID}, Categorie_bilet_ID = {bilete.Categorie_bilet_ID} " +
                          $"WHERE BiletID = {bilete.BiletID}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(bilete);
        }

        // GET: Bilete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilete = await _context.Bilete
                .FirstOrDefaultAsync(m => m.BiletID == id);
            if (bilete == null)
            {
                return NotFound();
            }

            return View(bilete);
        }

        // POST: Bilete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var sql = $"DELETE FROM Bilete WHERE BiletID = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool BileteExists(int id)
        {
            return _context.Bilete.Any(e => e.BiletID == id);
        }
    }
}

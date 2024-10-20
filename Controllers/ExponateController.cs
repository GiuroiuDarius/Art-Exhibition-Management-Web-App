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
    public class ExponateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExponateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Exponate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exponate.ToListAsync());
        }


        // GET: Exponate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sql1 = "SELECT e.*, c.Nume " +
                      "FROM Exponate e " +
                      "JOIN Artisti c ON e.ArtistID = c.ArtistID " +
                      $"WHERE e.ExponatId = {id}";


            var exponateDetails1 = await _context.DTO_Exponate.FromSqlRaw(sql1).FirstOrDefaultAsync();


            if (exponateDetails1 == null)
            {
                return NotFound();
            }

            ViewBag.Nume = exponateDetails1.Nume;

            return View(exponateDetails1);
        }


        // GET: Exponate/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm2()
        {
            return View();
        }

        // POST: Exponate/ShowSearchResults2
        public async Task<IActionResult> ShowSearchResults2(String SearchPhrase)
        {
            
            var sql = "SELECT e.* FROM Exponate e " +
              "JOIN Categorii_de_exponate c ON e.CategorieID = c.CategorieID " +
              $"WHERE c.Tipul_de_exponat LIKE '%{SearchPhrase}%'";

            var sql1 = "SELECT e.* FROM Exponate e " +
              "JOIN Artisti c ON e.ArtistID = c.ArtistID " +
              $"WHERE c.Nume LIKE '%{SearchPhrase}%'";

            var sql2 = "SELECT e.* FROM Exponate e " +
              "JOIN Artisti c ON e.ArtistID = c.ArtistID " +
              $"WHERE c.E_mail LIKE '%{SearchPhrase}%'";


            var sql5 = "SELECT e.* " +
                       "FROM Exponate e " +
                       "JOIN (SELECT TOP 1 ExpozitieID " +
                         " FROM Expozitii " +
                         $" WHERE Locatie LIKE '%{SearchPhrase}%' " +
                         " ORDER BY Numar_exponate DESC) c ON e.ExpozitieID = c.ExpozitieID";

            var sql6 = "SELECT e.* " +
                      "FROM Exponate e " +
                      "JOIN (SELECT TOP 1 ExpozitieID " +
                        " FROM Expozitii " +
                        $" WHERE Numar_exponate LIKE '%{SearchPhrase}%' " +
                        " ORDER BY Numar_exponate DESC) c ON e.ExpozitieID = c.ExpozitieID";

            var sql7 = "SELECT e.* " +
                      "FROM Exponate e " +
                      "JOIN (SELECT TOP 1 ExpozitieID " +
                        " FROM Expozitii " +
                        $" WHERE Nume_expozitie LIKE '%{SearchPhrase}%' " +
                        " ORDER BY Nume_expozitie DESC) c ON e.ExpozitieID = c.ExpozitieID";

            var sql4 = "SELECT e.* " +
                     "FROM Exponate e " +
                     "JOIN (SELECT TOP 1 ExpozitieID " +
                       " FROM Expozitii " +
                       $" WHERE Nume_expozitie LIKE '%{SearchPhrase}%' " +
                       " ORDER BY Nume_expozitie DESC) c ON e.ExpozitieID = c.ExpozitieID";


            var searchResults = await _context.Exponate.FromSqlRaw(sql).ToListAsync();
            var searchResults1 = await _context.Exponate.FromSqlRaw(sql1).ToListAsync();
            var searchResults2 = await _context.Exponate.FromSqlRaw(sql2).ToListAsync();
            var searchResults3 = await _context.Exponate.FromSqlRaw(sql7).ToListAsync();
            var searchResults4 = await _context.Exponate.FromSqlRaw(sql4).ToListAsync();
            var searchResults5 = await _context.Exponate.FromSqlRaw(sql5).ToListAsync();
            var searchResults6 = await _context.Exponate.FromSqlRaw(sql6).ToListAsync();




            if (searchResults.Count != 0)
            {
                return View("Index", searchResults);

            } else if (searchResults1.Count != 0)
            {
                return View("Index", searchResults1);
            } else if (searchResults2.Count != 0)
            {
                return View("Index", searchResults2);
            } else if (searchResults3.Count != 0)
            {
                return View("Index", searchResults3);
            }
            else if (searchResults4.Count != 0)
            {
                return View("Index", searchResults4);
            }
            else if (searchResults5.Count != 0)
            {
                return View("Index", searchResults5);
            } else if (searchResults6.Count != 0)
            {
                return View("Index", searchResults6);
            }

            return View("Index", searchResults1);


        }



        // GET: Exponate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exponate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExponatId,Nume_exponat,Descriere,An_fabricatie,ExpozitieID,ArtistID,CategorieID")] Exponate exponate)
        {
            if (ModelState.IsValid)
            {

                var sql = "INSERT INTO Exponate (Nume_exponat, Descriere, An_fabricatie, ExpozitieID, ArtistID, CategorieID) VALUES " +
                          "(@Nume_exponat, @Descriere, @An_fabricatie, @ExpozitieID, @ArtistID, @CategorieID)";

                await _context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Nume_exponat", exponate.Nume_exponat),
                    new SqlParameter("@Descriere", exponate.Descriere),
                    new SqlParameter("@An_fabricatie", exponate.An_fabricatie),
                    new SqlParameter("@ExpozitieID", exponate.ExpozitieID),
                    new SqlParameter("@ArtistID", exponate.ArtistID),
                    new SqlParameter("@CategorieID", exponate.CategorieID));
                return RedirectToAction(nameof(Index));
            }
            return View(exponate);
        }

        // GET: Exponate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exponate = await _context.Exponate.FindAsync(id);
            if (exponate == null)
            {
                return NotFound();
            }
            return View(exponate);
        }

        // POST: Exponate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExponatId,Nume_exponat,Descriere,An_fabricatie,ExpozitieID,ArtistID,CategorieID")] Exponate exponate)
        {
            if (id != exponate.ExponatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
 
                var sql = $"UPDATE Exponate SET Nume_exponat = '{exponate.Nume_exponat}', Descriere = '{exponate.Descriere}', " +
                            $"An_fabricatie = {exponate.An_fabricatie}, ExpozitieID = {exponate.ExpozitieID}, ArtistID = {exponate.ArtistID}, CategorieID = {exponate.CategorieID} " +
                            $"WHERE ExponatId = {exponate.ExponatId}";

                await _context.Database.ExecuteSqlRawAsync(sql);
                return RedirectToAction(nameof(Index));
            }
            return View(exponate);
        }

        // GET: Exponate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exponate = await _context.Exponate
                .FirstOrDefaultAsync(m => m.ExponatId == id);
            if (exponate == null)
            {
                return NotFound();
            }

            return View(exponate);
        }

        // POST: Exponate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sql = $"DELETE FROM Exponate WHERE ExponatId = {id}";
            await _context.Database.ExecuteSqlRawAsync(sql);
            return RedirectToAction(nameof(Index));
        }

        private bool ExponateExists(int id)
        {
            return _context.Exponate.Any(e => e.ExponatId == id);
        }
    }
}

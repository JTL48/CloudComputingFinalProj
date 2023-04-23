using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class HouseholdController : Controller
    {
        private readonly cloudcomputingfinalprojdatasciencedatabaseContext _context;

        public HouseholdController(cloudcomputingfinalprojdatasciencedatabaseContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var households = new List<Household>();

            // This allows the home page to load if migrations have not been run yet.
            try
            {
                households = await _context.Households.ToListAsync();
            }
            catch (Exception e)
            {

                return View(households);
            }

            return View(households);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var households = await _context.Households
                .FirstOrDefaultAsync(m => m.HshdNum == id);
            if (households == null)
            {
                return NotFound();
            }

            return View(households);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HshdNum,L,AgeRange,Marital,IncomeRange,Homeowner,HshdComposition,HhSize,Children")] Household households)
        {
            if (ModelState.IsValid)
            {
                _context.Add(households);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(households);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var households = await _context.Households.FindAsync(id);
            if (households == null)
            {
                return NotFound();
            }
            return View(households);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HshdNum,L,AgeRange,Marital,IncomeRange,Homeowner,HshdComposition,HhSize,Children")] Household households)
        {
            if (id != households.HshdNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(households);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseHoldExists(households.HshdNum))
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
            return View(households);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var households = await _context.Households
                .FirstOrDefaultAsync(m => m.HshdNum == id);
            if (households == null)
            {
                return NotFound();
            }

            return View(households);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var households = await _context.Households.FindAsync(id);
            _context.Households.Remove(households);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseHoldExists(int id)
        {
            return _context.Households.Any(e => e.HshdNum == id);
        }
    }
}

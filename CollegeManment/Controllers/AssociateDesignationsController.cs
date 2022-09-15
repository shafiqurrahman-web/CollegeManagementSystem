using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagement.Data;
using CollegeManagement.Models;

namespace CollegeManagement.Controllers
{
    public class AssociateDesignationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociateDesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssociateDesignations
        public async Task<IActionResult> Index()
        {
              return _context.AssociateDesignation != null ? 
                          View(await _context.AssociateDesignation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AssociateDesignation'  is null.");
        }

        // GET: AssociateDesignations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssociateDesignation == null)
            {
                return NotFound();
            }

            var associateDesignation = await _context.AssociateDesignation
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (associateDesignation == null)
            {
                return NotFound();
            }

            return View(associateDesignation);
        }

        // GET: AssociateDesignations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssociateDesignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignationId,DesignationName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] AssociateDesignation associateDesignation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associateDesignation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associateDesignation);
        }

        // GET: AssociateDesignations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssociateDesignation == null)
            {
                return NotFound();
            }

            var associateDesignation = await _context.AssociateDesignation.FindAsync(id);
            if (associateDesignation == null)
            {
                return NotFound();
            }
            return View(associateDesignation);
        }

        // POST: AssociateDesignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesignationId,DesignationName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] AssociateDesignation associateDesignation)
        {
            if (id != associateDesignation.DesignationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associateDesignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateDesignationExists(associateDesignation.DesignationId))
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
            return View(associateDesignation);
        }

        // GET: AssociateDesignations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssociateDesignation == null)
            {
                return NotFound();
            }

            var associateDesignation = await _context.AssociateDesignation
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (associateDesignation == null)
            {
                return NotFound();
            }

            return View(associateDesignation);
        }

        // POST: AssociateDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssociateDesignation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AssociateDesignation'  is null.");
            }
            var associateDesignation = await _context.AssociateDesignation.FindAsync(id);
            if (associateDesignation != null)
            {
                _context.AssociateDesignation.Remove(associateDesignation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateDesignationExists(int id)
        {
          return (_context.AssociateDesignation?.Any(e => e.DesignationId == id)).GetValueOrDefault();
        }
    }
}

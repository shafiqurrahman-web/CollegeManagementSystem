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
    public class AssociateTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociateTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssociateTypes
        public async Task<IActionResult> Index()
        {
              return _context.AssociateType != null ? 
                          View(await _context.AssociateType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AssociateType'  is null.");
        }

        // GET: AssociateTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssociateType == null)
            {
                return NotFound();
            }

            var associateType = await _context.AssociateType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (associateType == null)
            {
                return NotFound(); 
            }

            return View(associateType);
        }

        // GET: AssociateTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssociateTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] AssociateType associateType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associateType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associateType);
        }

        // GET: AssociateTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssociateType == null)
            {
                return NotFound();
            }

            var associateType = await _context.AssociateType.FindAsync(id);
            if (associateType == null)
            {
                return NotFound();
            }
            return View(associateType);
        }

        // POST: AssociateTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] AssociateType associateType)
        {
            if (id != associateType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associateType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateTypeExists(associateType.TypeId))
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
            return View(associateType);
        }

        // GET: AssociateTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssociateType == null)
            {
                return NotFound();
            }

            var associateType = await _context.AssociateType
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (associateType == null)
            {
                return NotFound();
            }

            return View(associateType);
        }

        // POST: AssociateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssociateType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AssociateType'  is null.");
            }
            var associateType = await _context.AssociateType.FindAsync(id);
            if (associateType != null)
            {
                _context.AssociateType.Remove(associateType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateTypeExists(int id)
        {
          return (_context.AssociateType?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}

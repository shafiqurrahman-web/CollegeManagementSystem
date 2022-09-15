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
    public class StudentRegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentRegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentRegistrations
        public async Task<IActionResult> Index()
        {
              return _context.StudentRegistration != null ? 
                          View(await _context.StudentRegistration.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentRegistration'  is null.");
        }

        // GET: StudentRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistration
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,MiddleName,LastName,FatherName,MotherName,ContactAddress,MobileNo,Gender,LandPhone,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistration.FindAsync(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }
            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,MiddleName,LastName,FatherName,MotherName,ContactAddress,MobileNo,Gender,LandPhone,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentRegistration studentRegistration)
        {
            if (id != studentRegistration.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentRegistrationExists(studentRegistration.StudentId))
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
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistration
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentRegistration == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentRegistration'  is null.");
            }
            var studentRegistration = await _context.StudentRegistration.FindAsync(id);
            if (studentRegistration != null)
            {
                _context.StudentRegistration.Remove(studentRegistration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentRegistrationExists(int id)
        {
          return (_context.StudentRegistration?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}

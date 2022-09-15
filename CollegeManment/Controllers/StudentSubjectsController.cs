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
    public class StudentSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
              return _context.StudentSubjects != null ? 
                          View(await _context.StudentSubjects.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentSubjects'  is null.");
        }

        // GET: StudentSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentSubjects == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (studentSubjects == null)
            {
                return NotFound();
            }

            return View(studentSubjects);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentSubjects studentSubjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentSubjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentSubjects);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentSubjects == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects.FindAsync(id);
            if (studentSubjects == null)
            {
                return NotFound();
            }
            return View(studentSubjects);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentSubjects studentSubjects)
        {
            if (id != studentSubjects.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectsExists(studentSubjects.SubjectId))
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
            return View(studentSubjects);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentSubjects == null)
            {
                return NotFound();
            }

            var studentSubjects = await _context.StudentSubjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (studentSubjects == null)
            {
                return NotFound();
            }

            return View(studentSubjects);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentSubjects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentSubjects'  is null.");
            }
            var studentSubjects = await _context.StudentSubjects.FindAsync(id);
            if (studentSubjects != null)
            {
                _context.StudentSubjects.Remove(studentSubjects);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectsExists(int id)
        {
          return (_context.StudentSubjects?.Any(e => e.SubjectId == id)).GetValueOrDefault();
        }
    }
}

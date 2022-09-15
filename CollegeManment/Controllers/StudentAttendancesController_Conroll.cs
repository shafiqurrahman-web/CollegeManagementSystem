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
    public class StudentAttendancesController_Conroll : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentAttendancesController_Conroll(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentAttendances
        public async Task<IActionResult> Index()
        {
              return _context.StudentAttendance != null ? 
                          View(await _context.StudentAttendance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentAttendance'  is null.");
        }

        // GET: StudentAttendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentAttendance == null)
            {
                return NotFound();
            }

            var studentAttendance = await _context.StudentAttendance
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            return View(studentAttendance);
        }

        // GET: StudentAttendances/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// get all data from  database from attendance table  to show this to list you can edit and show details and create new records 
        /// </summary>
        /// <param name="studentAttendance"></param>
        /// <returns></returns>

        // POST: StudentAttendances/Create
        // To protect from overposting attacks, ekkkghfhgnable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,StudentId,AttendanceDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentAttendance == null)
            {
                return NotFound();
            }

            var studentAttendance = await _context.StudentAttendance.FindAsync(id);
            if (studentAttendance == null)
            {
                return NotFound();
            }
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Edit/5
        // To protect from overpossdfgouyting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,StudentId,AttendanceDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] StudentAttendance studentAttendance)
        {
            if (id != studentAttendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAttendanceExists(studentAttendance.AttendanceId))
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
            return View(studentAttendance);
        }

        // GET: StudentAttendlopitgttttlkuytooiuytces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentAttendance == null)
            {
                return NotFound();
            }

            var studentAttendance = await _context.StudentAttendance
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            return View(studentAttendance);
        }

        // POST: StudentAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentAttendance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentAttendance'  is null.");
            }
            var studentAttendance = await _context.StudentAttendance.FindAsync(id);
            if (studentAttendance != null)
            {
                _context.StudentAttendance.Remove(studentAttendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAttendanceExists(int id)
        {
          return (_context.StudentAttendance?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}

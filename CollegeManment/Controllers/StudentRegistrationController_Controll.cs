using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Controllers
{
    public class StudentRegistrationController_Controll : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentRegistrationController_Controll(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.StudentRegistration != null ?
                View(await _context.StudentRegistration.ToListAsync()) :
                Problem("There is no data in student Registration tables");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _context.StudentRegistration.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
                return NotFound();

            StudentRegistration? studentRegistration = await _context.StudentRegistration.FirstOrDefaultAsync(x => x.StudentId == id);

            if (studentRegistration == null) return NotFound();
            return View(studentRegistration);

        }

        [HttpGet]
        public IActionResult InsertStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertStudent([Bind("StudentId")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentRegistration);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }
            StudentRegistration? studentRegistration = await _context.StudentRegistration.FindAsync(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }
            return View(studentRegistration);

        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(int? id, [Bind("StudentId")] StudentRegistration studentRegistration)
        {
            if (id != studentRegistration.StudentId)
            {
                return NotFound();
            }
            //var data  = await _context.StudentRegistration.FindAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.StudentRegistration.FirstOrDefaultAsync(x => x.StudentId == id);
                    _context.Update(studentRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!(_context.StudentAttendance?.Any(x => x.StudentId == id)).GetValueOrDefault())
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

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentReg = await _context.StudentRegistration.FirstOrDefaultAsync(x => x.StudentId == id);
            if (studentReg == null)
            {
                return NotFound();
            }
            return View(studentReg);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if (id == null || _context.StudentRegistration == null)
            {
                return NotFound();
            }

            var studentReg = await _context.StudentRegistration.FindAsync(id);
            if (studentReg == null)
            {
                return NotFound();
            }
            _context.StudentRegistration.Remove(studentReg);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

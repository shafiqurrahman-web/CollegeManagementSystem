using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Controllers
{
    public class AssociateTypeController_Controll : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AssociateTypeController_Controll(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return _applicationDbContext.AssociateType != null ?
                View(await _applicationDbContext.AssociateType.ToListAsync()) :
                Problem("There is no data in student Registration tables");
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id)
        {
            if (_applicationDbContext.AssociateType == null)
            {
                return NotFound();
            }
            AssociateType? details = await _applicationDbContext.AssociateType.FirstOrDefaultAsync(m => m.TypeId == id);
            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }
        [HttpGet]
        public IActionResult CreateAssociate()
        {
            return View();
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAssociates([Bind("TypeId")] AssociateType associateType)
        {
            var result = this.ToString();


            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(associateType);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(associateType);
        }

        [HttpGet]
        public async Task<IActionResult> EditAssociate(int? id)
        {
            if (id == null || _applicationDbContext.AssociateType == null)
            {
                return NotFound();
            }
            var resultData = await _applicationDbContext.AssociateType.FindAsync(id);
            if (resultData == null)
            {
                return NotFound();
            }
            return View(resultData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAssociate(int? id, [Bind("TypeId")] AssociateType associateType)
        {
            if (id == null || _applicationDbContext.AssociateType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _applicationDbContext.AssociateType.FindAsync(id);
                    if (result == null)
                    {
                        return NotFound();
                    }

                    _applicationDbContext.Update(associateType);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(_applicationDbContext.AssociateType?.Any(x => x.TypeId == id)).GetValueOrDefault())
                    {
                        return NotFound();
                    }
                    else
                        throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAssociate(int? id)
        {
            if (id == null || _applicationDbContext.AssociateType == null)
            {
                return NotFound();
            }
            var associateType = await _applicationDbContext.AssociateType.FirstOrDefaultAsync(x => x.TypeId == id);
            if (associateType == null)
            {
                return NotFound();
            }
            return View(associateType);


        }
        [HttpPost, ActionName("DeleteAssociate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAssociateWithId(int? id)
        {
            if (id == null || _applicationDbContext.AssociateType == null)
            {
                return NotFound();
            }

            var associateType = await _applicationDbContext.AssociateType.FindAsync(id);
            if (associateType != null)
            {
                _applicationDbContext.Remove(associateType);
            }
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

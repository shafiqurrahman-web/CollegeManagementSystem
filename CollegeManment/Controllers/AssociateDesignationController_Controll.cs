using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Controllers
{
    public class AssociateDesignationController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AssociateDesignationController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _applicationDbContext.AssociateDesignation != null ?
                View(await _applicationDbContext.AssociateDesignation.ToListAsync())
                : Problem("associate designation is null");
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id)
        {
            if (id == null || _applicationDbContext.AssociateDesignation == null)
            {
                return NotFound();
            }
            var assoDesig = await _applicationDbContext.AssociateDesignation.FirstOrDefaultAsync(x => x.DesignationId == id);
            if (assoDesig == null)
            {
                return NotFound();
            }
            return View(assoDesig);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignationId")] AssociateDesignation associateDesignation)
        {
            //if (associateDesignation == null)
            //    return View(associateDesignation);

            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(associateDesignation);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associateDesignation);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id, [Bind("")] AssociateDesignation associateDesignation)
        {
            if (id == null || _applicationDbContext.AssociateDesignation == null)
            {
                return NotFound();
            }
            var resultData = await _applicationDbContext.AssociateDesignation.FindAsync(id);
            if (resultData == null)
            {
                return NotFound();
            }
            return View(resultData);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDesignation(int? id, [Bind("DesignationId")] AssociateDesignation associateDesignation)
        {
            if (id != associateDesignation.DesignationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _applicationDbContext.Update(associateDesignation);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(_applicationDbContext.AssociateDesignation?.Any(x => x.DesignationId == associateDesignation.DesignationId)).GetValueOrDefault())
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

        [HttpGet]
        public async Task<IActionResult> DeleteDesignation(int? id)
        {
            if (id == null || _applicationDbContext.AssociateDesignation == null)
            {
                return NotFound();
            }
            var result = await _applicationDbContext.AssociateDesignation.FirstOrDefaultAsync(x => x.DesignationId == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);

        }
        [HttpPost, ActionName("DeleteDesignation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDesinationConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var assoDesig = await _applicationDbContext.AssociateDesignation.FindAsync(id);
            if (assoDesig != null)
            {
                _applicationDbContext.Remove(assoDesig);
            }
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

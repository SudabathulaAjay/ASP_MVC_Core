using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_Core.Data;
using ASP_MVC_Core.Models;

namespace ASP_MVC_Core.Controllers
{
    public class AzureKeysController : Controller
    {
        private readonly ASP_MVC_CoreContext _context;

        public AzureKeysController(ASP_MVC_CoreContext context)
        {
            _context = context;
        }

        // GET: AzureKeys
        public async Task<IActionResult> Index()
        {
             
            return View(await _context.AzureKey.ToListAsync());
        }

        // GET: AzureKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var azureKey = await _context.AzureKey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (azureKey == null)
            {
                return NotFound();
            }

            return View(azureKey);
        }

        // GET: AzureKeys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AzureKeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,key")] AzureKey azureKey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(azureKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(azureKey);
        }

        // GET: AzureKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var azureKey = await _context.AzureKey.FindAsync(id);
            if (azureKey == null)
            {
                return NotFound();
            }
            return View(azureKey);
        }

        // POST: AzureKeys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,key")] AzureKey azureKey)
        {
            if (id != azureKey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(azureKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AzureKeyExists(azureKey.Id))
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
            return View(azureKey);
        }

        // GET: AzureKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var azureKey = await _context.AzureKey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (azureKey == null)
            {
                return NotFound();
            }

            return View(azureKey);
        }

        // POST: AzureKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var azureKey = await _context.AzureKey.FindAsync(id);
            _context.AzureKey.Remove(azureKey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AzureKeyExists(int id)
        {
            return _context.AzureKey.Any(e => e.Id == id);
        }
    }
}

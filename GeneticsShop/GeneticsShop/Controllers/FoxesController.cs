using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeneticsShop.Models;

namespace GeneticsShop.Controllers
{
    public class FoxesController : Controller
    {
        private readonly FOXContext _context;

        public FoxesController(FOXContext context)
        {
            _context = context;
        }

        // GET: Foxes
        public async Task<IActionResult> Index()
        {
            var fOXContext = _context.Foxes.Include(f => f.IdProductNavigation);
            return View(await fOXContext.ToListAsync());
        }

        // GET: Foxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foxes = await _context.Foxes
                .Include(f => f.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (foxes == null)
            {
                return NotFound();
            }

            return View(foxes);
        }

        // GET: Foxes/Create
        public IActionResult Create()
        {
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: Foxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,Tails")] Foxes foxes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foxes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", foxes.IdProduct);
            return View(foxes);
        }

        // GET: Foxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foxes = await _context.Foxes.FindAsync(id);
            if (foxes == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", foxes.IdProduct);
            return View(foxes);
        }

        // POST: Foxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,Tails")] Foxes foxes)
        {
            if (id != foxes.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foxes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoxesExists(foxes.IdProduct))
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
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", foxes.IdProduct);
            return View(foxes);
        }

        // GET: Foxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foxes = await _context.Foxes
                .Include(f => f.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (foxes == null)
            {
                return NotFound();
            }

            return View(foxes);
        }

        // POST: Foxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foxes = await _context.Foxes.FindAsync(id);
            _context.Foxes.Remove(foxes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoxesExists(int id)
        {
            return _context.Foxes.Any(e => e.IdProduct == id);
        }
    }
}

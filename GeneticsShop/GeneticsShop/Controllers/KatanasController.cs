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
    public class KatanasController : Controller
    {
        private readonly FOXContext _context;

        public KatanasController(FOXContext context)
        {
            _context = context;
        }

        // GET: Katanas
        public async Task<IActionResult> Index()
        {
            var fOXContext = _context.Katanas.Include(k => k.IdProductNavigation);
            return View(await fOXContext.ToListAsync());
        }

        // GET: Katanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var katanas = await _context.Katanas
                .Include(k => k.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (katanas == null)
            {
                return NotFound();
            }

            return View(katanas);
        }

        // GET: Katanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Katanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sharpness")] Katanas katanas, [Bind("Name,IdProductNavigation.Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                katanas.IdProductNavigation = new Product() { };

                _context.Add(product);
                await _context.SaveChangesAsync();
                katanas.IdProduct = product.Id;
                _context.Add(katanas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", katanas.IdProduct);
            return View(katanas);
        }

        // GET: Katanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var katanas = await _context.Katanas.FindAsync(id);
            if (katanas == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", katanas.IdProduct);
            return View(katanas);
        }

        // POST: Katanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,Sharpness")] Katanas katanas)
        {
            if (id != katanas.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(katanas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KatanasExists(katanas.IdProduct))
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
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", katanas.IdProduct);
            return View(katanas);
        }

        // GET: Katanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var katanas = await _context.Katanas
                .Include(k => k.IdProductNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (katanas == null)
            {
                return NotFound();
            }

            return View(katanas);
        }

        // POST: Katanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var katanas = await _context.Katanas.FindAsync(id);
            _context.Katanas.Remove(katanas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KatanasExists(int id)
        {
            return _context.Katanas.Any(e => e.IdProduct == id);
        }
    }
}

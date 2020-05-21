using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperHerois.Data;
using SuperHerois.Models;

namespace SuperHerois.Controllers
{
    public class SuperHeroisController : Controller
    {
        private readonly SuperHeroisContext _context;

        public SuperHeroisController(SuperHeroisContext context)
        {
            _context = context;
        }

        // GET: SuperHerois
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperHeroi.ToListAsync());
        }

        // GET: SuperHerois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHeroi = await _context.SuperHeroi
                .FirstOrDefaultAsync(m => m.id == id);
            if (superHeroi == null)
            {
                return NotFound();
            }

            return View(superHeroi);
        }

        // GET: SuperHerois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperHerois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,poder,fraqueza")] SuperHeroi superHeroi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHeroi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHeroi);
        }

        // GET: SuperHerois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHeroi = await _context.SuperHeroi.FindAsync(id);
            if (superHeroi == null)
            {
                return NotFound();
            }
            return View(superHeroi);
        }

        // POST: SuperHerois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,poder,fraqueza")] SuperHeroi superHeroi)
        {
            if (id != superHeroi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHeroi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperHeroiExists(superHeroi.id))
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
            return View(superHeroi);
        }

        // GET: SuperHerois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHeroi = await _context.SuperHeroi
                .FirstOrDefaultAsync(m => m.id == id);
            if (superHeroi == null)
            {
                return NotFound();
            }

            return View(superHeroi);
        }

        // POST: SuperHerois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superHeroi = await _context.SuperHeroi.FindAsync(id);
            _context.SuperHeroi.Remove(superHeroi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperHeroiExists(int id)
        {
            return _context.SuperHeroi.Any(e => e.id == id);
        }
    }
}

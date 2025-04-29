using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progreso1_EstefaniHuertas.Models;

namespace Progreso1_EstefaniHuertas.Controllers
{
    public class PlanRecompensasController : Controller
    {
        private readonly DbHuertas_Hotel _context;

        public PlanRecompensasController(DbHuertas_Hotel context)
        {
            _context = context;
        }

        // GET: PlanRecompensas
        public async Task<IActionResult> Index()
        {
            var dbHuertas_Hotel = _context.PlanRecompensa.Include(p => p.Cliente);
            return View(await dbHuertas_Hotel.ToListAsync());
        }

        // GET: PlanRecompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensa = await _context.PlanRecompensa
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PlanRecompensaId == id);
            if (planRecompensa == null)
            {
                return NotFound();
            }

            return View(planRecompensa);
        }

        // GET: PlanRecompensas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId");
            return View();
        }

        // POST: PlanRecompensas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanRecompensaId,Nombre,FechaInicio,ClienteId")] PlanRecompensa planRecompensa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planRecompensa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", planRecompensa.ClienteId);
            return View(planRecompensa);
        }

        // GET: PlanRecompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensa = await _context.PlanRecompensa.FindAsync(id);
            if (planRecompensa == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", planRecompensa.ClienteId);
            return View(planRecompensa);
        }

        // POST: PlanRecompensas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanRecompensaId,Nombre,FechaInicio,ClienteId")] PlanRecompensa planRecompensa)
        {
            if (id != planRecompensa.PlanRecompensaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planRecompensa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanRecompensaExists(planRecompensa.PlanRecompensaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", planRecompensa.ClienteId);
            return View(planRecompensa);
        }

        // GET: PlanRecompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planRecompensa = await _context.PlanRecompensa
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PlanRecompensaId == id);
            if (planRecompensa == null)
            {
                return NotFound();
            }

            return View(planRecompensa);
        }

        // POST: PlanRecompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planRecompensa = await _context.PlanRecompensa.FindAsync(id);
            if (planRecompensa != null)
            {
                _context.PlanRecompensa.Remove(planRecompensa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanRecompensaExists(int id)
        {
            return _context.PlanRecompensa.Any(e => e.PlanRecompensaId == id);
        }
    }
}

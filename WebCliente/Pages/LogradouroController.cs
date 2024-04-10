using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCliente.Data;
using WebCliente.Models;

namespace WebCliente.Pages
{
    public class LogradouroController : Controller
    {
        private readonly WebClienteContext _context;

        public LogradouroController(WebClienteContext context)
        {
            _context = context;
        }

        // GET: Logradouroes
        public async Task<IActionResult> Index()
        {
            var webClienteContext = _context.Logradouro;//.Include(l => l.Cliente);
            return View(await webClienteContext.ToListAsync());
        }

        // GET: Logradouroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro
                //.Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.LogradouroId == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // GET: Logradouroes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email");
            return View();
        }

        // POST: Logradouroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogradouroId,Endereco,ClienteId")] Logradouro logradouro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logradouro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", logradouro.ClienteId);
            return View(logradouro);
        }

        // GET: Logradouroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro.FindAsync(id);
            if (logradouro == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", logradouro.ClienteId);
            return View(logradouro);
        }

        // POST: Logradouroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogradouroId,Endereco,ClienteId")] Logradouro logradouro)
        {
            if (id != logradouro.LogradouroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logradouro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogradouroExists(logradouro.LogradouroId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", logradouro.ClienteId);
            return View(logradouro);
        }

        // GET: Logradouroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouro
                //.Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.LogradouroId == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // POST: Logradouroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logradouro = await _context.Logradouro.FindAsync(id);
            if (logradouro != null)
            {
                _context.Logradouro.Remove(logradouro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogradouroExists(int id)
        {
            return _context.Logradouro.Any(e => e.LogradouroId == id);
        }
    }
}

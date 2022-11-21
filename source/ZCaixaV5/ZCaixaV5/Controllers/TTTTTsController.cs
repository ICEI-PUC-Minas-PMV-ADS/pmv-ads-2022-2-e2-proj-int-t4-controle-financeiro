using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;

namespace ZCaixaV5.Controllers
{
    public class TTTTTsController : Controller
    {
        private readonly ZCaixaContexto _context;

        public TTTTTsController(ZCaixaContexto context)
        {
            _context = context;
        }

        // GET: TTTTTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TTTTT_1.ToListAsync());
        }

        // GET: TTTTTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTTTT = await _context.TTTTT_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tTTTT == null)
            {
                return NotFound();
            }

            return View(tTTTT);
        }

        // GET: TTTTTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTTTTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Username")] TTTTT tTTTT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tTTTT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tTTTT);
        }

        // GET: TTTTTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTTTT = await _context.TTTTT_1.FindAsync(id);
            if (tTTTT == null)
            {
                return NotFound();
            }
            return View(tTTTT);
        }

        // POST: TTTTTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,Username")] TTTTT tTTTT)
        {
            if (id != tTTTT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTTTT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTTTTExists(tTTTT.Id))
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
            return View(tTTTT);
        }

        // GET: TTTTTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTTTT = await _context.TTTTT_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tTTTT == null)
            {
                return NotFound();
            }

            return View(tTTTT);
        }

        // POST: TTTTTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tTTTT = await _context.TTTTT_1.FindAsync(id);
            _context.TTTTT_1.Remove(tTTTT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTTTTExists(int id)
        {
            return _context.TTTTT_1.Any(e => e.Id == id);
        }
    }
}

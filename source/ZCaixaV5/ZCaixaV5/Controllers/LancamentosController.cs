using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;
using static Composite.Core.Logging.LoggingService;

namespace ZCaixaV5.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly ZCaixaContexto _context;
        private readonly ZCaixaContexto _contextcat;

        public LancamentosController(ZCaixaContexto context)
        {
            _context = context;
            _contextcat = context;
        }

        // GET: Lancamentos
        public async Task<IActionResult> Index(int? pageNumber)
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int pageSize = 2;
                
                var categoria = from c in _context.Categorias
                                select c;
                categoria = categoria.Where(c => c.Username.Contains(HttpContext.User.Identity.Name));
                categoria = categoria.OrderBy(c => c.Nome);

                var lancamento = from s in _context.Lancamentos
                                select s;
                lancamento = lancamento.Where(s => s.Username.Contains(HttpContext.User.Identity.Name));
                lancamento = lancamento.OrderByDescending(s => s.Data);
   
                return View(await PaginaList<Lancamento>.CreateAsync(lancamento.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
        }

        // GET: Lancamentos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }
            var categoria = await _contextcat.Categorias
                .FirstOrDefaultAsync(m => m.Id == lancamento.CatId);
            
            return View(lancamento);
        }

        // GET: Lancamentos/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.TipoLanId = new SelectList
                    (
                        new TipoLan().ListaTiposLan(),
                        "TipoLanId",
                        "NomeLan"
                    );
            return View();
        }

        // POST: Lancamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Descricao,Tipo,Valor,Conciliado,Username,CatId")] Lancamento lancamento, string TipoLanId)
        {
            lancamento.Tipo = TipoLanId;
            lancamento.Conciliado = false;
            lancamento.Username = HttpContext.User.Identity.Name;
            ViewBag.TipoLanId = new SelectList
                    (
                        new TipoLan().ListaTiposLan(),
                        "TipoLanId",
                        "NomeLan",
                        TipoLanId
                    );
            if (ModelState.IsValid)
            {
                var erro = false;
                if (lancamento.Tipo != "C" && lancamento.Tipo != "D")
                {
                    ViewData["Message"] = "Tipo só pode ser (C)Crédito ou (D)Débito";
                    erro = true;
                }
                if (erro)
                {
                    return View();
                }
                _context.Add(lancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lancamento);
        }

        // GET: Lancamentos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            ViewBag.TipoLanId = new SelectList
                    (
                        new TipoLan().ListaTiposLan(),
                        "TipoLanId",
                        "NomeLan",
                        lancamento.Tipo
                    );
            return View(lancamento);
        }

        // POST: Lancamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Descricao,Tipo,Valor,Conciliado,Username,CatId")] Lancamento lancamento, string TipoLanId)
        {
            if (id != lancamento.Id)
            {
                return NotFound();
            }
            lancamento.Tipo = TipoLanId;
            lancamento.Username = HttpContext.User.Identity.Name;
            ViewBag.TipoLanId = new SelectList
                    (
                        new TipoLan().ListaTiposLan(),
                        "TipoLanId",
                        "NomeLan",
                        TipoLanId
                    );
            if (ModelState.IsValid)
            {
                var erro = false;
                if (lancamento.Tipo != "C" && lancamento.Tipo != "D")
                {
                    ViewData["Message"] = "Tipo só pode ser (C)Crédito ou (D)Débito";
                    erro = true;
                }
                if (erro)
                {
                    return View();
                }
                try
                {
                    _context.Update(lancamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancamentoExists(lancamento.Id))
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
            return View(lancamento);
        }

        // GET: Lancamentos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lancamento = await _context.Lancamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }
            if (lancamento.Conciliado == true)
            {
                return Content("Alerta", "Não pode excluir um lançamento já conciliado");
            }
            return View(lancamento);
        }

        // POST: Lancamentos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Cadastro de Categorias (Atalho)
        public IActionResult Categoria()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Create", "Categorias");
            }
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.Id == id);
        }
    }
}

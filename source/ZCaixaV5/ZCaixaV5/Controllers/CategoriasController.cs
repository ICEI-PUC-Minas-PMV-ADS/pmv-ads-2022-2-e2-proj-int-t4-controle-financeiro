﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;

namespace ZCaixaV5.Controllers

{
    public class CategoriasController : Controller
    {
        private readonly ZCaixaContexto _context;

        public CategoriasController(ZCaixaContexto context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(int? pageNumber)
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int pageSize = 2;
                var categoria = from s in _context.Categorias
                               select s;
                categoria = categoria.Where(s => s.Username.Contains(HttpContext.User.Identity.Name));
                categoria = categoria.OrderBy(s => s.Nome);
                return View(await PaginaList<Categoria>.CreateAsync(categoria.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
        }

        // GET: Categorias/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.TipoId = new SelectList
                    (
                        new Tipo().ListaTipos(),
                        "TipoId",
                        "Nome"
                    );
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Username")] Categoria categoria, string TipoId)
        {
            categoria.Tipo = TipoId;
            categoria.Username = HttpContext.User.Identity.Name;
            ViewBag.TipoId = new SelectList
                    (
                        new Tipo().ListaTipos(),
                        "TipoId",
                        "Nome",
                        TipoId
                    );
            if (ModelState.IsValid)
            {
                var erro = false;
                if (NomeExists(categoria.Nome))
                {
                    //ViewBag.Mensage = "Já existe uma categoria com esse nome.";
                    ViewData["Message"] = "Já existe uma categoria com esse nome.";
                    erro = true;
                }
                if (categoria.Tipo != "R" && categoria.Tipo != "D")
                {
                    //ViewBag.Mensage2 = "Tipo só pode ser (R)Receita ou (D)Despesa";
                    ViewData["Message2"] = "Tipo só pode ser (R)Receita ou (D)Despesa";
                    erro = true;
                }
                if (erro)
                {
                    return View();
                }
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            ViewBag.TipoId = new SelectList
                    (
                        new Tipo().ListaTipos(),
                        "TipoId",
                        "Nome", 
                        categoria.Tipo
                    );
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,Username")] Categoria categoria, string TipoId)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            categoria.Tipo = TipoId;
            categoria.Username = HttpContext.User.Identity.Name;
            ViewBag.TipoId = new SelectList
                    (
                        new Tipo().ListaTipos(),
                        "TipoId",
                        "Nome",
                        TipoId
                    );

            if (ModelState.IsValid)
            {
                var erro = false;
                /* Tirei essa condição de baixo porque sempre vai 
                 * existir o lançamento, pois se trata de uma alteração
                    
                if (NomeExists(categoria.Nome))
                {
                    //ViewBag.Mensage = "Já existe uma categoria com esse nome.";
                    ViewData["Message"] = "Já existe uma categoria com esse nome.";
                    erro = true;
                }
                */
                if (categoria.Tipo != "R" && categoria.Tipo != "D")
                {
                    //ViewBag.Mensage2 = "Tipo só pode ser (R)Receita ou (D)Despesa";
                    ViewData["Message2"] = "Tipo só pode ser (R)Receita ou (D)Despesa";
                    erro = true;
                }
                if (erro)
                {
                    return View();
                }
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
        private bool NomeExists(string nome)
        {
            return _context.Categorias.Any(e => e.Nome == nome);
        }

    }
   
}

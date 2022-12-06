using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Composite.Core.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;
using static Composite.Core.Logging.LoggingService;

namespace ZCaixaV5.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly ZCaixaContexto _context;
        private readonly ZCaixaContexto _contextcat;
        private readonly ZCaixaContexto _contextusr;

        public LancamentosController(ZCaixaContexto context)
        {
            _context = context;
            _contextcat = context;
            _contextusr = context;
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
                Usuario usuario = await _contextusr.Usuarios.FindAsync(HttpContext.User.Identity.Name);
                ViewBag.mesConsulta = usuario.MesConsulta;
                ViewBag.anoConsulta = usuario.AnoConsulta;



                ViewBag.Nome = HttpContext.User.Identity.Name;
                var categoria = from c in _contextcat.Categorias
                                select c;
                categoria = categoria.Where(c => c.Username.Contains(HttpContext.User.Identity.Name));
                categoria = categoria.OrderBy(c => c.Nome);

                List<SelectListItem> itens = new List<SelectListItem>();
                foreach (Categoria w in categoria)
                {
                    itens.Add(new SelectListItem { Text = w.Nome, Value = w.Id.ToString() });
                }

                ViewBag.Categ = itens;

                ViewBag.TipoLanId = new SelectList
                     (
                         new TipoLan().ListaTiposLan(),
                         "TipoLanId",
                         "NomeLan"
                     );
                int pageSize = 13;
                var lancamento = from s in _context.Lancamentos.Include(s => s.Cat)
                                 select s;
                lancamento = lancamento.Where(s => s.Username.Contains(HttpContext.User.Identity.Name));
                lancamento = lancamento.Where(s => s.Data.Year == usuario.AnoConsulta);
                lancamento = lancamento.Where(s => s.Data.Month == usuario.MesConsulta);
                lancamento = lancamento.OrderByDescending(s => s.Id).OrderByDescending(s => s.Data);
                return View(await PaginaList<Lancamento>.CreateAsync(lancamento.AsNoTracking(), pageNumber ?? 1, pageSize));           
            }
        }

        [HttpPost]
        public async Task<JsonResult> NovoLancamento(Lancamento lancamento)
        {
            lancamento.Conciliado = false;
            lancamento.Username = HttpContext.User.Identity.Name;
            
            if (ModelState.IsValid)
            {               
                _context.Add(lancamento);
                await _context.SaveChangesAsync();
                return Json(lancamento);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<JsonResult> PegarLancamento(int lancamentoId)
        {
            Lancamento lancamento = await _context.Lancamentos.FindAsync(lancamentoId);
            
            return Json(lancamento);
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarFiltroMes(int IDMes)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _contextusr.Usuarios.FindAsync(HttpContext.User.Identity.Name);
                usuario.MesConsulta = IDMes;                
                _contextusr.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return Json(IDMes);
            }

            return Json(ModelState);
        }
        [HttpPost]
        public async Task<JsonResult> AtualizarFiltroAno(int IDAno)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _contextusr.Usuarios.FindAsync(HttpContext.User.Identity.Name);
                usuario.AnoConsulta = IDAno;
                _contextusr.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return Json(IDAno);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarLancamento(Lancamento lancamento)
        {
            lancamento.Conciliado = false;
            lancamento.Username = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Lancamentos.Update(lancamento);
                await _context.SaveChangesAsync();
                return Json(lancamento);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirLancamento(int lancamentoId)
        {
            Lancamento lancamento = await _context.Lancamentos.FindAsync(lancamentoId);

            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Lancamentos");
            }

            return Json(new
            {
                mensagem = "Lançamento não encontrado"
            });
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

        public List<Lancamento> GetLancamentos()
        {
            List<Lancamento> model = new List<Lancamento>();
            var lancamento = from s in _context.Lancamentos.Include(s => s.Cat)
                             select s;
            lancamento = lancamento.Where(s => s.Username.Contains(HttpContext.User.Identity.Name));
            lancamento = lancamento.OrderByDescending(s => s.Id).OrderByDescending(s => s.Data);
            model.AddRange(lancamento);
            return model;
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Composite.Core.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Authentication;
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
                ViewBag.Nome = usuario.Nome;
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
                if (TempData["Pagina"] != null)
                {
                    pageNumber = 1;
                    TempData["Pagina"] = null;                    
                };
                var lancamento = from s in _context.Lancamentos.Include(s => s.Cat)
                                 select s;
                lancamento = lancamento.Where(s => s.Username.Contains(HttpContext.User.Identity.Name));
                decimal totalReceitaG = 0;
                decimal totalDespesaG = 0;
                decimal totalSaldoG = 0;
                decimal totalReceitaP = 0;
                decimal totalDespesaP = 0;
                decimal totalSaldoP = 0;
                decimal totalMeta = 0;
                int percMeta = 0;
                foreach (Lancamento lanG in lancamento)
                {
                    if (lanG.Cat.Tipo == "R")
                    {
                        if (lanG.Tipo == "C")
                        {
                            totalReceitaG = totalReceitaG + lanG.Valor;
                        }
                        else if (lanG.Tipo == "D")
                        {
                            totalReceitaG = totalReceitaG - lanG.Valor;
                        }
                    }
                    else if (lanG.Cat.Tipo == "D")
                    {
                        if (lanG.Tipo == "D")
                        {
                            totalDespesaG = totalDespesaG + lanG.Valor;
                        }
                        else if (lanG.Tipo == "C")
                        {
                            totalDespesaG = totalDespesaG - lanG.Valor;
                        }
                    }
                };

                if (usuario.AnoConsulta > 0)
                {
                    lancamento = lancamento.Where(s => s.Data.Year == usuario.AnoConsulta);
                }
                if (usuario.MesConsulta > 0)
                {
                    lancamento = lancamento.Where(s => s.Data.Month == usuario.MesConsulta);
                }
                lancamento = lancamento.OrderByDescending(s => s.Id).OrderByDescending(s => s.Data);

                var cultureInfo = Thread.CurrentThread.CurrentCulture;
                var numberFormatInfo = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
                var vlrF = "";
                List<CategoriaEntradaValor> ListaE = new List<CategoriaEntradaValor>();
                List<CategoriaSaidaValor> ListaS = new List<CategoriaSaidaValor>();
                foreach (Lancamento lanP in lancamento)
                {
                    if (lanP.Cat.Tipo == "R")
                    {
                        CategoriaEntradaValor existeE = ListaE.FirstOrDefault(e => e.Categoria == lanP.Cat.Nome);
                        if (existeE != null)
                        {
                            if (lanP.Tipo == "C")
                            {
                                existeE.Valor = existeE.Valor + lanP.Valor; 
                            }
                            else if (lanP.Tipo == "D")
                            {
                                existeE.Valor = existeE.Valor - lanP.Valor;
                            }
                            existeE.ValorF = string.Format(numberFormatInfo, "{0:C}", existeE.Valor);
                        }
                        else
                        {
                            if (lanP.Tipo == "C")
                            {
                                vlrF = string.Format(numberFormatInfo, "{0:C}", lanP.Valor);
                                ListaE.Add(new CategoriaEntradaValor { Categoria = lanP.Cat.Nome, Valor = lanP.Valor, ValorF = vlrF });
                            }
                            else if (lanP.Tipo == "D")
                            {
                
                                vlrF = string.Format(numberFormatInfo, "{0:C}", lanP.Valor * -1);
                                ListaE.Add(new CategoriaEntradaValor { Categoria = lanP.Cat.Nome, Valor = lanP.Valor * -1, ValorF = vlrF });
                            }
                        }
                            
                        if (lanP.Tipo == "C")
                        {
                            totalReceitaP = totalReceitaP + lanP.Valor;
                        }
                        else if (lanP.Tipo == "D")
                        {
                            totalReceitaP = totalReceitaP - lanP.Valor;
                        }
                    }
                    else if (lanP.Cat.Tipo == "D")
                    {
                        CategoriaSaidaValor existeS = ListaS.FirstOrDefault(s => s.Categoria == lanP.Cat.Nome);
                        if (existeS != null)
                        {
                            if (lanP.Tipo == "D")
                            {
                                existeS.Valor = existeS.Valor + lanP.Valor;
                            }
                            else if (lanP.Tipo == "C")
                            {
                                existeS.Valor = existeS.Valor - lanP.Valor;
                            }
                            existeS.ValorF = string.Format(numberFormatInfo, "{0:C}", existeS.Valor);
                        }
                        else
                        {
                            if (lanP.Tipo == "D")
                            {
                                vlrF = string.Format(numberFormatInfo, "{0:C}", lanP.Valor);
                                ListaS.Add(new CategoriaSaidaValor { Categoria = lanP.Cat.Nome, Valor = lanP.Valor, ValorF = vlrF });
                            }
                            else if (lanP.Tipo == "C")
                            {
                                vlrF = string.Format(numberFormatInfo, "{0:C}", lanP.Valor * -1);
                                ListaS.Add(new CategoriaSaidaValor { Categoria = lanP.Cat.Nome, Valor = lanP.Valor * -1, ValorF = vlrF });
                            }
                        }
                        if (lanP.Tipo == "D")
                        {
                            totalDespesaP = totalDespesaP + lanP.Valor;
                        }
                        else if (lanP.Tipo == "C")
                        {
                            totalDespesaP = totalDespesaP - lanP.Valor;
                        }
                    }
                }
                totalSaldoG = totalReceitaG - totalDespesaG;
                totalMeta = usuario.Meta;
                if (totalMeta == 0)
                {
                    percMeta = 0;
                }
                else if (totalMeta < totalSaldoG)
                {
                    percMeta = 100;
                }
                else
                {
                    percMeta = (int)(totalSaldoG / totalMeta * 100);
                }
                totalSaldoP = totalReceitaP - totalDespesaP;
                vlrF = string.Format(numberFormatInfo, "{0:C}", totalReceitaP);
                ViewBag.Receita = vlrF;
                vlrF = string.Format(numberFormatInfo, "{0:C}", totalDespesaP);
                ViewBag.Despesa = vlrF;
                vlrF = string.Format(numberFormatInfo, "{0:C}", totalSaldoP);
                ViewBag.Saldo = vlrF;
                ViewBag.ValorMeta = totalMeta;
                ViewBag.PercMeta = percMeta;
                List<CategoriaEntradaValor> ListaESort = ListaE.OrderBy(x => x.Categoria).ToList();
                List<CategoriaSaidaValor> ListaSSort = ListaS.OrderBy(x => x.Categoria).ToList();
                ViewBag.Entradas = ListaESort;
                ViewBag.Saidas = ListaSSort;       
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
        [HttpPost]
        public async Task<JsonResult> NovoLancamentoCategoria(Categoria categoria)
        {
            categoria.Username = HttpContext.User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                var categ = from c in _context.Categorias
                            select c;
                categ = categ.Where(c => c.Username.Contains(HttpContext.User.Identity.Name));
                categ = categ.OrderBy(c => c.Nome);

                List<SelectListItem> itens = new List<SelectListItem>();
                foreach (Categoria w in categ)
                {
                    itens.Add(new SelectListItem { Text = w.Nome, Value = w.Id.ToString() });
                }

                ViewBag.Categ = itens;
                return Json(categoria);
            }
            return Json(ModelState);
        }





        [HttpGet]
        public async Task<IActionResult> SairSistema()
        {
            var userClaims = new List<Claim>()
                    {
                        //define o cookie
                        new Claim(ClaimTypes.Name, ""),
                    };
            var minhaIdentity = new ClaimsIdentity(userClaims, "usr");
            var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
            //cria o cookie
            await HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<JsonResult> PegarLancamento(int lancamentoId)
        {
            Lancamento lancamento = await _context.Lancamentos.FindAsync(lancamentoId);
            
            return Json(lancamento);
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarMeta(string ValorMetaS)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _contextusr.Usuarios.FindAsync(HttpContext.User.Identity.Name);
                usuario.Meta = Convert.ToDecimal(ValorMetaS);
                _contextusr.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return Json(ValorMetaS);
            }
            return Json(ModelState);
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
        public JsonResult IniciarPagina(int IDAno)
        {
            TempData["Pagina"] = "IniciarPagina";
            return Json(IDAno);
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

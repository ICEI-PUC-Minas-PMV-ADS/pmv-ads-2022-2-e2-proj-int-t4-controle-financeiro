using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Aspnet_AuthCookies1.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZCaixaV5.Api.Data;
using ZCaixaV5.Models;

namespace Aspnet_AuthCookies1.Controllers
{
    namespace ZCaixaV5.Controllers
    {


        public class UsuariosController : Controller
        {
            private readonly ZCaixaContexto _context;

            public UsuariosController(ZCaixaContexto context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login([Bind("Username,Senha")] Usuario usuario)
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Username == usuario.Username || m.Email == usuario.Email);

                if (user == null)
                {
                    ViewBag.Message = "Usuário e/ou Senha incorretos.";
                    return View();
                }
                await HttpContext.SignOutAsync();
                var nome = user.Nome;
                bool SenhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

                if (SenhaOk)
                {
                    ViewBag.Saudar = "Bem vindo, ";
                    ViewBag.Message = nome;
                    ViewBag.Message1 = "!";
                    var userClaims = new List<Claim>()
                    {
                        //define o cookie
                        new Claim(ClaimTypes.Name, usuario.Username),
                    };
                    var minhaIdentity = new ClaimsIdentity(userClaims, "usr");
                    var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
                    //cria o cookie
                    await HttpContext.SignInAsync(userPrincipal);
                    //return View();
                    return RedirectToAction("Index", "Lancamentos");
                }

                ViewBag.Message = "Usuário e/ou Senha incorretos.";
                return View();
            }



            // GET: Usuarios
            //public async Task<IActionResult> Index()
            //{
            //    return View(await _context.Usuarios.ToListAsync());
            //}

            // GET: Usuarios/Details/5
            public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Username == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return View();
            }

            // GET: Usuarios/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Usuarios/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Username,Nome,UltimoNome,Senha,Email,Telefone,DataNascimento,Meta,MesConsulta,AnoConsulta")] Usuario usuario)
            {
                if (ModelState.IsValid)
                {
                    if (UsuarioExists(usuario.Username))
                    {
                        ViewBag.Mensage = "Este usuário já existe.";
                        return View();
                    }

                    if (EmailExists(usuario.Email))
                    {
                        ViewBag.Mensage2 = "Já existe um cadastro utilizando este e-mail.";
                        return View();
                    }

                    usuario.Meta = 0;
                    var Data = DateTime.Now;
                    usuario.MesConsulta = Data.Month;
                    usuario.AnoConsulta = Data.Year;
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                return View();
            }

            // GET: Usuarios/Edit/5
            public async Task<IActionResult> Edit(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }

            // POST: Usuarios/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(string id, [Bind("Username,Nome,UltimoNome,Senha,Email,Telefone,DataNascimento,Meta,MesConsulta,AnoConsulta")] Usuario usuario)
            {
                if (id != usuario.Username)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //criptografando a senha inserida na tabela de usuário.
                        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.Username))
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
                return View(usuario);
            }

            // GET: Usuarios/Delete/5
            public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Username == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return View(usuario);
            }

            // POST: Usuarios/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(string id)
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool UsuarioExists(string id)
            {
                return _context.Usuarios.Any(e => e.Username == id);
            }

            private bool EmailExists(string email)
            {
                return _context.Usuarios.Any(e => e.Email == email);
            }



            public IActionResult RecuperaSenha()
            {
                return View();
            }

            private bool VerificaNome(string nome)
            {
                return _context.Usuarios.Any(e => e.Nome == nome);
            }

            private bool VerificaDataNascimento(DateTime data)
            {
                return _context.Usuarios.Any(e => e.DataNascimento == data);
            }
            /*public async Task<IActionResult> RecuperaSenha(string id)
            {

                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }*/

            [HttpPost]
            [ValidateAntiForgeryToken]

            public async Task<IActionResult> RecuperaSenha(string id, [Bind("Username,Nome,Email,DataNascimento")] Usuario usuario)
            {
                if (id != usuario.Username)
                {
                    ViewBag.Message = "Usuário não encontrado.";
                    return View();
                }

                if (!EmailExists(usuario.Email) || !VerificaNome(usuario.Nome) || !VerificaDataNascimento(usuario.DataNascimento))
                {
                    ViewBag.Message = "Algum dado informado está incorreto.";
                    return View();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Remove(usuario.Senha);
                        _context.Add(BCrypt.Net.BCrypt.HashPassword(usuario.Senha));
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.Username))
                        {
                            ViewBag.Message = "Usuário não encontrado.";
                            return View();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Login));
                }
                return View(Login());
            }



        }
    }
}

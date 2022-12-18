using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Http;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebMatrix;
using Microsoft.EntityFrameworkCore;
using ZCaixaV5.Api.Data;
using BCrypt.Net;
using ZCaixaV5.Models;
using Microsoft.IdentityModel.Protocols;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Antlr.Runtime.Misc;
using Newtonsoft.Json;
using System.Data;

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
                    .FirstOrDefaultAsync(m => m.Username == usuario.Username || m.Email == usuario.Username || m.Telefone == usuario.Username);

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
                    usuario = user;
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
            public IActionResult Create(string Senha2)
            {
                Senha2 = "";
                return View();
            }

            // POST: Usuarios/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Username,Nome,UltimoNome,Senha,Email,Telefone,DataNascimento,Meta,MesConsulta,AnoConsulta")] Usuario usuario, string Senha2, bool Check)
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

                    if (TelefoneExists(usuario.Telefone))
                    {
                        ViewBag.Mensage2 = "Já existe um cadastro utilizando este telefone.";
                        return View();
                    }

                    if (usuario.DataNascimento < DateTime.Now)
                    {
                        int idade = CalculaIdade(usuario.DataNascimento);
                        if (idade < 16)
                        {
                            ViewBag.Mensage5 = "Usuário precisa ter mais de 16 anos";
                            return View();
                        }
                        if (idade > 25)
                        {
                            ViewBag.Mensage5 = "Essa ferramenta permite cadastro de usuários até 25 anos";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Mensage5 = "Data inválida...";
                        return View();
                    }

                    if (usuario.Telefone.Length > 11)
                    {
                        ViewBag.Mensage2 = "Telefone não pode ter mais de 11 dígitos...";
                        return View();
                    }

                    if (usuario.Senha != Senha2)
                    {
                        ViewBag.Mensage3 = "Senhas não conferem.. Verifique";
                        return View();
                    }

                    if (!Check)
                    {
                        ViewBag.Mensage4 = "É necessário concordar com os termos...";
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

            private bool TelefoneExists(string telefone)
            {
                return _context.Usuarios.Any(e => e.Telefone == telefone);
            }

            private static int CalculaIdade(DateTime Data)
            {
                int idade = DateTime.Now.Year - Data.Year;
                if (DateTime.Now.DayOfYear < Data.DayOfYear)
                {
                    idade = idade - 1;
                }
                return idade;
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
            public async Task<IActionResult> RecuperaSenha([Bind("Username")] Usuario usuario)
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Username == usuario.Username || m.Email == usuario.Username || m.Telefone == usuario.Username);

                if (user == null)
                {
                    ViewBag.Message = "Algum dado informado está incorreto.";
                    return View();
                }
                usuario = user;

                
                var callbackUrl = Url.Action("RedefinirSenha", "Conta", new { id = user.Username }, protocol: Request.Scheme);
          
                string apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("ricardo.teixeira@criadoresdesoftware.com.br", "ZCaixa - Não responder esse Email");
                var subject = "Código de segurança ZCaixa";
                var to = new EmailAddress(usuario.Email, usuario.Nome + " " + usuario.UltimoNome); 
                Random random = new Random();
                int libera = random.Next(99999, 999999);
                var plainTextContent = "O Código de segurança para o ZCaixa é:" + libera;
                var htmlContent = "O Código de segurança para o ZCaixa é : <strong> " + libera + " </strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                CodigoSeguranca codigoseguranca = new CodigoSeguranca
                {
                    Username = usuario.Username,
                    CodEmail = libera,
                    Digitado = 0,
                    Senha = null
                };
                TempData["CodigoSeguranca"] = JsonConvert.SerializeObject(codigoseguranca);
                return RedirectToAction(nameof(DigitaCodigo));
            }

            [HttpGet]
            public IActionResult DigitaCodigo()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DigitaCodigo(CodigoSeguranca codigoseguranca)
            {
                if (TempData["CodigoSeguranca"] != null)
                {
                    var cseg = JsonConvert.DeserializeObject<CodigoSeguranca>((string)TempData["CodigoSeguranca"]);
                    if (cseg.CodEmail != codigoseguranca.Digitado)
                    {
                        TempData["CodigoSeguranca"] = JsonConvert.SerializeObject(cseg);
                        ViewBag.Message = "Código de Segurança Inválido";
                        return View();
                    }
                    cseg.Digitado = codigoseguranca.Digitado;
                    TempData["CodigoSeguranca"] = JsonConvert.SerializeObject(cseg);
                    return RedirectToAction(nameof(AlteraSenha));
                }
                return View();
            }

            [HttpGet]
            public IActionResult AlteraSenha()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AlteraSenha(CodigoSeguranca codigoseguranca)
            {
                if (TempData["CodigoSeguranca"] != null)
                {
                    var cseg = JsonConvert.DeserializeObject<CodigoSeguranca>((string)TempData["CodigoSeguranca"]);
                    cseg.Senha = codigoseguranca.Senha;
                    var usuario = await _context.Usuarios.FindAsync(cseg.Username);
                    if (cseg.Username != usuario.Username)
                    {
                        TempData["CodigoSeguranca"] = JsonConvert.SerializeObject(cseg);
                        return NotFound();
                    }
                    if (codigoseguranca.Senha == null)
                    {
                        TempData["CodigoSeguranca"] = JsonConvert.SerializeObject(cseg);
                        ViewBag.Message = "Senha precisa ser digitada";
                        return View();
                    }
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(codigoseguranca.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                return View();
            }
        }
    }
}

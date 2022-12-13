using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; 
using ControleDeEstoque.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using PagedList.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeEstoque.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ControleDeEstoqueContext _context;

        public UsuariosController(ControleDeEstoqueContext context)
        {
            _context = context;
        }


        //login

        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("EmailUsuario, Senha")] Usuario usuario)

        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.EmailUsuario == usuario.EmailUsuario);

            if (user == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos";
                return View();
            }

            bool isSenhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

            if (isSenhaOk)
            {
                var claims = new List<Claim>

                {
                    new Claim(ClaimTypes.Name, user.EmailUsuario)

                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);


                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");

            }
            ViewBag.Message = "Não logado por outra razão";
            return View();

        }

        //acesso negado 

        public IActionResult AccessDenied() //inserir o caminho no cookieoptions
        {
            return View();
        }

        //logout

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }

        //pesquisa 

        public async Task<IActionResult> Index(string searchString)
        {
            var u = from p
                       in _context.Usuarios
                       select p;

            if (String.IsNullOrEmpty(searchString) == false)
            {
                u = from x in _context.Usuarios
                    where x.EmailUsuario.Contains(searchString)
                    orderby x.EmailUsuario select x;
                           
            }

            return View(await u.ToListAsync());
        }




       


        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailUsuario,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha); //necessário inserir o bccrypt aqui
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailUsuario,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ControleDeEstoqueContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeEstoque.Models;

namespace ControleDeEstoque.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ControleDeEstoqueContext _context;

        public ProdutosController(ControleDeEstoqueContext context)
        {
            _context = context;
        }

        // GET: Produtos
      
            public async Task<IActionResult> Index(string searchString, string listaCategoria)

            {
                if (_context.Produtos == null)
                {
                    return Problem("A entidade ControleDeEstoque.Produtos é nula");
                }

                IQueryable<string> categoriaQuery = from x in _context.Produtos
                                                    orderby x.Categoria
                                                    select x.Categoria; // categoria

                var prod = from x in _context.Produtos
                           select x; //toda a tabela


                if (!String.IsNullOrEmpty(searchString)) //olha o nome do produto

                {
                    prod = from x in _context.Produtos
                           where x.NomeDoProduto.Contains(searchString)
                           select x;
                }
                if (!String.IsNullOrEmpty(listaCategoria))

                {
                    prod = from x in _context.Produtos
                           where x.Categoria == listaCategoria
                           select x;
                }

                var catprodMD = new CategoriaProdutoViewModel
                {
                    ListaDeCategorias = new SelectList(await categoriaQuery.Distinct().ToArrayAsync()),
                    ListaDeProdutos = await prod.ToListAsync()

                };
                return View(catprodMD);
            }

        

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDoProduto,Categoria,Preco,EnumFornecedores")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDoProduto,Categoria,Preco,EnumFornecedores")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'ControleDeEstoqueContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return _context.Produtos.Any(e => e.Id == id);
        }
    }
}

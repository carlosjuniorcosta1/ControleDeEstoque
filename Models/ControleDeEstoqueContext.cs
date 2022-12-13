using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleDeEstoque.Models;

namespace ControleDeEstoque.Models
{
    public class ControleDeEstoqueContext:DbContext

    {


        public ControleDeEstoqueContext(DbContextOptions<ControleDeEstoqueContext> options)
            : base(options)
            {

        }

       public DbSet<Usuario> Usuarios { get; set; }

       public DbSet<Cliente> Clientes { get; set; }

       public DbSet<Produto> Produtos { get; set; }

       public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<CategoriaProdutoViewModel> Categorias { get; set; }


    }

}

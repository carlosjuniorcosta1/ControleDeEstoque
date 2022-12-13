using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.Models

{
    public class CategoriaProdutoViewModel
    {
        public int Id { get; set; }

        [NotMapped]
        public SelectList? ListaDeCategorias { get; set; }

        public string? CategoriaClasseCategoria { get; set; }

        public string? SearchString { get; set;  }

        public List<Produto>? ListaDeProdutos { get; set; }

        public Produto? Produtos { get; set; }


    }
}

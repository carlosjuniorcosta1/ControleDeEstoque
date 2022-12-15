using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]

        public string? NomeDoProduto { get; set; }
        public string? Categoria { get; set; }

        [Display(Name = "Preço do produto")]
        public decimal? Preco { get; set; }

    }




}
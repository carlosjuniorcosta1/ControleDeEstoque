using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.Models
{
    public class PesquisaClientes
    {
        public int Id { get; set; }

        [NotMapped]
        public SelectList? SelectNomeClientes { get; set; }

        [NotMapped]
        public SelectList? SelectNomeCidades { get; set; }


        public string? SearchString { get; set; }

        public EnumPesquisaSelecionada PesquisaSelecionada { get; set; }

        public List<Cliente>? SelectClasseClientes { get; set; }

        public Cliente? Clientes { get; set; }
    }

    public enum EnumPesquisaSelecionada
    {
        Nome, 
        Cidade
    }
}

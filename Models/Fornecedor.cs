using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ControleDeEstoque.Models
{
    public class Fornecedor
    {

        
        public int? Id { get; set;  }

        public string? NomeDoFornecedor { get; set; }

        public ICollection <Produto>? Produtos { get; set;  }

        
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string EmailUsuario { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }

   
}



using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastro.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail.")]
        public string Email { get; set; }
        
    }
}

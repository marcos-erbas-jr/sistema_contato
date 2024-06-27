using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastro.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha.")]
        public string Senha { get; set; }
    }
}

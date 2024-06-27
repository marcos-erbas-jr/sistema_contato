using SistemaDeCadastro.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastro.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório.")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }
    }
}

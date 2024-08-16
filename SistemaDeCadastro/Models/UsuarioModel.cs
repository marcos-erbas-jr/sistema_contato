using SistemaDeCadastro.Enums;
using SistemaDeCadastro.Helper;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastro.Models
{
    public class UsuarioModel
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório.")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public PerfilEnum Perfil { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash(); //Transforma a senha do usuário em um
                                    //Hash, que será armazenado no banco de dados
        }
    }
}

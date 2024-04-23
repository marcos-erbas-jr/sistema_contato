using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage ="E-mail inválido.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório.")]
        [Phone(ErrorMessage ="O celular informado não é válido.")]
        public string? Celular { get; set; }

        //Observação: Todos os campos estão aceitando null por utilizar o '?' depois do tipo

    }
}


using ControledeContatos.Models;
using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Models;

namespace ControledeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

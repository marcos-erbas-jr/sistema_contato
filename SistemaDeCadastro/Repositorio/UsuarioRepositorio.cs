using ControledeContatos.Data;
using ControledeContatos.Models;
using SistemaDeCadastro.Models;

namespace ControledeContatos.Repositorio
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //gravar no banco de dados
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização.");
            else
            {
                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Login = usuario.Login;
                usuarioDB.Email = usuario.Email;
                usuarioDB.Perfil = usuario.Perfil;
                usuarioDB.DataAtualizacao = DateTime.Now;

                _bancoContext.Usuarios.Update(usuarioDB);
                _bancoContext.SaveChanges();
                return usuarioDB;
            }
        }

        public List<UsuarioModel> BuscarTodos()
        {
            //Mostrar dados do banco
            return _bancoContext.Usuarios.ToList();
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Houve um erro na exclusão");
            else
            {
                _bancoContext.Usuarios.Remove(usuarioDB);
                _bancoContext.SaveChanges();
                return true;
            }
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(b => b.Id == id);
        }
    }
}
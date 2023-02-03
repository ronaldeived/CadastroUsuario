using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEntity
{
    public class LoginContext
    {
        private BaseContext db = new BaseContext();
        public Usuario Login(string login, string senha)
        {
            var usuario = db.Usuario.Include("Usuario_Perfis").Where(a => a.Login.Equals(login) && a.Senha.Equals(senha)).FirstOrDefault();
            return usuario;
        }
    }
}
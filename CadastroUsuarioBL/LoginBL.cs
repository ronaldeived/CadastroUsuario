using CadastroUsuarioEntity;
using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioBL
{
    public class LoginBL
    {
        private LoginContext db = new LoginContext();
        public Usuario Login(string login, string senha)
        {
            return db.Login(login, senha);
        }
    }
}

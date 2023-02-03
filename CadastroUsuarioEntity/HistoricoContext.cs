using CadastroUsuarioModels;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUsuarioEntity
{
    public class HistoricoContext
    {
        private BaseContext db = new BaseContext();
        public List<Usuario_Processo> GetUsuarioProcesso()
        {
            return db.Usuario_Processo.ToList();
        }
    }
}

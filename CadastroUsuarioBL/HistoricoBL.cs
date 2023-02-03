using System.Collections.Generic;
using CadastroUsuarioEntity;
using CadastroUsuarioModels;

namespace CadastroUsuarioBL
{
    public class HistoricoBL
    {
        private HistoricoContext db = new HistoricoContext();

        public List<Usuario_Processo> GetUsuarioProcesso()
        {
            return db.GetUsuarioProcesso();
        }
    }
}

using CadastroUsuarioDAL;
using CadastroUsuarioEntity;
using CadastroUsuarioModels;
using System.Collections.Generic;

namespace CadastroUsuarioBL
{
    public class ProcessoBL
    {
        private ProcessoContext db = new ProcessoContext();
        private ProcessoDAL dal = new ProcessoDAL();

        public List<Processo> HomeProcesso(List<decimal> lista_status)
        {
            return db.HomeProcesso(lista_status);
        }

        public decimal CadastrarProcesso(Processo processo)
        {
            if (processo != null)
            {
                return db.CadastrarProcesso(processo);
            }
            else
                return new decimal(null);
        }

        public Processo GetProcesso(decimal id)
        {
            return db.GetProcesso(id);
        }

        public bool PostEditar(Processo processo)
        {
            if (processo != null)
            {
                db.PostEditar(processo);
                return true;
            }
            else
                return false;
        }

        public bool ExcluirProcesso(decimal id)
        {
            if (id != 0)
            {
                db.Excluir(id);
                return true;
            }
            else
                return false;
        }
    }
}

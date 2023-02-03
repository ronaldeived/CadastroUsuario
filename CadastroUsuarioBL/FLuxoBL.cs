using CadastroUsuarioDAL;
using CadastroUsuarioEntity;
using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioBL
{
    public class FluxoBL
    {
        private FluxoContext db = new FluxoContext();
        private ProcessoContext pDB = new ProcessoContext();

        public void EncaminhaGerente(decimal id_processo, decimal id_usuario)
        {
            db.EncaminhaGerente(id_processo);
            var processo = pDB.GetProcesso(id_processo);
            Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
        }

        public void EncaminhaCorrecao(decimal id_processo, decimal id_usuario)
        {
            db.EncaminhaCorrecao(id_processo);
            var processo = pDB.GetProcesso(id_processo);
            Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
        }

        public void AprovarGerente(decimal id_processo, decimal id_usuario)
        {
            if (VerificaSeUsuarioCadastrou(id_processo, id_usuario))
            {
                if (db.VerificaNacionalidade(id_processo) == 1)
                {
                    db.Aprovar(id_processo);
                    var processo = pDB.GetProcesso(id_processo);
                    Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
                }
                else
                {
                    db.EncaminhaControleRisco(id_processo);
                    var processo = pDB.GetProcesso(id_processo);
                    Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
                }
            }
        }

        public void AprovarControleRisco(decimal id_processo, decimal id_usuario)
        {
            if (VerificaSeUsuarioCadastrou(id_processo, id_usuario))
            {
                db.Aprovar(id_processo);
                var processo = pDB.GetProcesso(id_processo);
                Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
            }
        }

        public void Reprovar(decimal id_processo, decimal id_usuario)
        {
            db.Reprovar(id_processo);
            var processo = pDB.GetProcesso(id_processo);
            Rastreabilidade(id_processo, id_usuario, processo.Id_Status);
        }

        public void Rastreabilidade(decimal id_processo, decimal id_usuario, decimal id_status)
        {
            db.Rastreabilidade(id_processo, id_usuario, id_status);
        }

        public bool VerificaSeUsuarioCadastrou(decimal id_processo, decimal id_usuario)
        {
            var result = db.VerificaSeUsuarioCadastrou(id_processo);
            var status = result.Id_Status;
            var usuario = result.Id_Usuario;
            if (status == 4 && usuario != id_usuario)
                return true;
            else
                return false;
        }
    }
}

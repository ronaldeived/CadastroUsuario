using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEntity
{
    public class FluxoContext
    {
        private BaseContext db = new BaseContext();

        public decimal VerificaNacionalidade(decimal id)
        {
            var teste = (from Processo in db.Processo
                         join Cidade in db.Cidade on Processo.Id_Cidade equals Cidade.Id_Cidade
                         join Estado in db.Estado on Cidade.Id_Estado equals Estado.Id_Estado
                         where Processo.Id_Processo == id
                         select Estado.Id_Pais);

            return teste.FirstOrDefault();
        }

        public void EncaminhaGerente(decimal id)
        {
            var result = db.Processo.SingleOrDefault(b => b.Id_Processo == id);
            result.Id_Status = 1;
            db.SaveChanges();
        }

        public void EncaminhaControleRisco(decimal id)
        {
            var result = db.Processo.SingleOrDefault(b => b.Id_Processo == id);
            result.Id_Status = 6;
            db.SaveChanges();
        }

        public void EncaminhaCorrecao(decimal id)
        {
            var result = db.Processo.SingleOrDefault(b => b.Id_Processo == id);
            result.Id_Status = 5;
            db.SaveChanges();
        }

        public void Aprovar(decimal id)
        {
            var result = db.Processo.SingleOrDefault(b => b.Id_Processo == id);
            result.Id_Status = 3;
            db.SaveChanges();
        }

        public void Reprovar(decimal id)
        {
            var result = db.Processo.SingleOrDefault(b => b.Id_Processo == id);
            result.Id_Status = 2;
            db.SaveChanges();
        }

        public void Rastreabilidade(decimal id_processo, decimal id_usuario, decimal id_status)
        {
            var usuario_Processo = new Usuario_Processo { Id_Processo = id_processo, Id_Usuario = id_usuario, Id_Status = id_status, Data_Entrada = DateTime.Now, Data_Saida = DateTime.Now };
            db.Usuario_Processo.Add(usuario_Processo);
            db.SaveChanges();
        }

        public Usuario_Processo VerificaSeUsuarioCadastrou(decimal id_processo)
        {
            var result = db.Usuario_Processo.First(p => p.Id_Processo == id_processo);
            return result;
        }
    }
}

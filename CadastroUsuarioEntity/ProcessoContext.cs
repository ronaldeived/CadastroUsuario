using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CadastroUsuarioEntity
{
    public class ProcessoContext : BaseContext
    {
        private BaseContext db = new BaseContext();

        public List<Processo> HomeProcesso(List<decimal> id_status)
        {
            return db.Processo.Where(p => id_status.Contains(p.Id_Status)).ToList();
        }
        public decimal CadastrarProcesso(Processo processo)
        {
            var novo_processo = processo;
            novo_processo.Id_Status = 4;
            db.Processo.Add(novo_processo);
            db.SaveChanges();
            var id_processo = novo_processo.Id_Processo;
            return id_processo;
        }
        
        public Processo GetProcesso(decimal id)
        {
            return db.Processo.Find(id);
        }

        public void PostEditar(Processo processo)
        {
            db.Entry(processo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(decimal id)
        {
            db.Processo.Remove(db.Processo.Find(id));
            db.SaveChanges();
        }
    }
}
using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEntity
{
    public class CidadeContext
    {
        private BaseContext db = new BaseContext();

        public List<Pais> GetListaPais()
        {
            return db.Pais.ToList();
        }

        public List<Estado> GetListaEstado(decimal id_Pais)
        {
            return (from Estado in db.Estado
                    where Estado.Id_Pais == id_Pais
                    select Estado).ToList();
        }

        public List<Cidade> GetListaCidade(decimal id_Estado)
        {
            return (from Cidade in db.Cidade
                    where Cidade.Id_Estado == id_Estado
                    select Cidade).ToList();
        }
    }
}

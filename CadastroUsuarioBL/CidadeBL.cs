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
    public class CidadeBL
    {
        private CidadeContext db = new CidadeContext();
        public List<Pais> GetListaPais()
        {
            return db.GetListaPais();
        }

        public List<Estado> GetListaEstado(decimal id_Pais)
        {
            return db.GetListaEstado(id_Pais);
        }

        public List<Cidade> GetListaCidade(decimal id_Estado)
        {
            return db.GetListaCidade(id_Estado);
        }

        public void GetEspecificoEstado(decimal id_Pais)
        {
            GetListaEstado(id_Pais);
        }

        public void GetEspecificoCidade(decimal id_Estado)
        {
            GetListaCidade(id_Estado);
        }
    }
}

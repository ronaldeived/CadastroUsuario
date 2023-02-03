using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioMvc
{
    public class ViewModelProcesso
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public List<Processo> Processos { get; set; }
    }
}

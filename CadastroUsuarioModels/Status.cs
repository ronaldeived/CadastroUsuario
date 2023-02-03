using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("STATUS")]
    public class Status
    {
        public Status()
        {
            Processos = new HashSet<Processo>();
            Usuario_Processos = new HashSet<Usuario_Processo>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Id_Status { get; set; }

        [Display(Name ="Status")]
        public string Descricao { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }

        public virtual ICollection<Usuario_Processo> Usuario_Processos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    public class Usuario_Processo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id_Usuario_Processo { get; set; }

        public decimal Id_Usuario { get; set; }

        public decimal Id_Processo { get; set; }

        public decimal Id_Status { get; set; }

        public DateTime Data_Entrada { get; set; }

        public DateTime Data_Saida { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Processo Processo { get; set; }

        public virtual Status Status { get; set; }
    }
}

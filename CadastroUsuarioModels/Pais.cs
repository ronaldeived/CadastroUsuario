using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("PAIS")]
    public class Pais
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        [Key]
        public decimal Id_Pais { get; set; }

        [Display(Name = "Pais")]
        public string Nome { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}

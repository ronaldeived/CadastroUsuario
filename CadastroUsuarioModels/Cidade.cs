using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("CIDADE")]
    public class Cidade
    {
        public Cidade()
        {
            Processos = new HashSet<Processo>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id_Cidade { get; set; }

        public decimal Id_Estado { get; set; }

        [Display(Name="Cidade")]
        public string Nome { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }
    }
}

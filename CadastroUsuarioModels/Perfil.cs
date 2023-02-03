using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("PERFIL")]
    public class Perfil
    {
        public Perfil()
        {
            Usuario_Perfis = new HashSet<Usuario_Perfil>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal Id_Perfil { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Usuario_Perfil> Usuario_Perfis { get; set; }
    }
}

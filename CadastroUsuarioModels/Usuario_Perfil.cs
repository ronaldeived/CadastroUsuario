using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("USUARIO_PERFIL")]
    public class Usuario_Perfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id_Usuario_Perfil { get; set; }

        public decimal Id_Usuario { get; set; }

        public decimal Id_Perfil { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}

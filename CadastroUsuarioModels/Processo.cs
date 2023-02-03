using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioModels
{
    [Table("PROCESSO")]
    public class Processo
    {
       
        public Processo()
        {
            Usuario_Processos = new HashSet<Usuario_Processo>();
        }

        [Display(Name = "Processo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G10}")]
        public decimal Id_Processo { get; set; }

        [Display(Name = "Id_Cidade")]
        [Column(TypeName = "numeric")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G10}")]
        public decimal Id_Cidade { get; set; }
        
        [Display(Name = "Id_Status")]
        [Column(TypeName = "numeric")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G10}")]
        public decimal Id_Status { get; set; }
        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe o CPF", AllowEmptyStrings = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G11}")]
        public decimal Cpf { get; set; }
        
        [Display(Name = "RG")]
        [Required()]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G9}")]
        public decimal Rg { get; set; }
        
        [Display(Name = "Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Nascimento { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o E-mail", AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Informe o CEP", AllowEmptyStrings = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G8}")]
        public decimal Cep { get; set; }
        
        [Display(Name = "Rua")]
        [Required()]
        public string Rua { get; set; }
        
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Informe o número", AllowEmptyStrings = false)]
        public string Numero { get; set; }
        
        [Display(Name = "Complemento")]
        [Required()]
        public string Complemento { get; set; }
        
        [Display(Name = "Bairro")]
        [Required()]
        public string Bairro { get; set; }
        
        [Display(Name = "Celular")]
        [Required()]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G11}")]
        public decimal Celular { get; set; }
        
        [Display(Name = "Sexo")]
        [Required()]
        public string Sexo { get; set; }

        [ForeignKey("Id_Cidade")]
        public virtual Cidade Cidade { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Usuario_Processo> Usuario_Processos { get; set; }
    }
}

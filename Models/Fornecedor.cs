using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinal.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {

        [Column("FornecedorId")]
        [Display(Name = "Código do Fornecedor")]
        public int FornecedorId { get; set; }

        [Column("FornecedorNome")]
        [Display(Name = "Nome")]
        public string FornecedorName { get; set; } = string.Empty;

        [Column("FornecedorEmail")]
        [Display(Name = "Email")]
        public string FornecedorEmail { get; set;} = string.Empty;
    }
}

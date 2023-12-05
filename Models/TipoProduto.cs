using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("TipoProdutoId")]
        [Display(Name = "Código do Tipo Produto")]
        public int TipoProdutoId { get; set; }

        [Column("TipoProdutoDescricao")]
        [Display(Name = "Tipo Produto Descriação")]
        public string TipoProdutoDescricao { get; set; } = string.Empty;
    }
}

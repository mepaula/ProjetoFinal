using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinal.Models
{
    [Table("Projeto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do Produto")]
        public int ProdutoId { get; set; }

        [Column("ProdutoNome")]
        [Display(Name = "Nome")]
        public string ProdutoName { get; set; } = string.Empty;

        [Column("ProdutoEstoque")]
        [Display(Name = "Estoque")]
        public string ProdutoEstoque { get; set; } = string.Empty;

        [ForeignKey("FornecedorId")]
        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        [ForeignKey("TipoProdutoId")]
        [Display(Name = "Tipo Produto")]
        public int TipoProdutoId { get; set; }
        public TipoProduto? TipoProduto { get; set; }
    }
}

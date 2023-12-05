using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("TipoSaida")]
    public class TipoSaida
    {
        [Column("TipoSaidaId")]
        [Display(Name = "Código do Tipo Saida")]
        public int TipoSaidaId { get; set; }

        [Column("TipoSaidaDescricao")]
        [Display(Name = "Tipo de Saída Descrição")]
        public string TipoSaidaDescricao { get; set;  } = string.Empty;
    }
}

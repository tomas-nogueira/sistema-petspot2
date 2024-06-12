using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackIt.Models
{
    [Table("Observacoes")]
    public class Observacoes
    {
        [Column("ObservacoesId")]
        [Display(Name = "Cód. da Observação")]

        public int ObservacoesId { get; set; }

        [Column("ObservacoesDescricao")]
        [Display(Name = "Descrição da Observação")]

        public string ObservacoesDescricao { get; set; } = string.Empty;

        [Column("ObservacoesLocal")]
        [Display(Name = "Local da Observação")]

        public string ObservacoesLocal { get; set; } = string.Empty;

        [Column("ObservacoesData")]
        [Display(Name = "Data da Observação")]

        public DateTime ObservacoesData { get; set; }

        [ForeignKey("AnimalsId")]
        public int AnimalsId { get; set; }
        public Animals? Animals { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}

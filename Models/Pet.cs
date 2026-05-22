using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClivoVetApi.Models
{
    [Table("TB_CLIVO_PET")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A espécie é obrigatória")]
        [StringLength(50)]
        public string Especie { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        public double Peso { get; set; }
        
        [StringLength(20)]
        public string StatusAtividade { get; set; } = "Normal";
        
        public DateTime UltimaSincronizacao { get; set; } = DateTime.Now;
    }
}

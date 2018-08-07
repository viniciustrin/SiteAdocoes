using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.Models
{
    public class Especie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string NomeEspecie { get; set; }
    }
}
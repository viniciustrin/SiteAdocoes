using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.Models
{
    public class Porte
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string NomePorte { get; set; }
    }
}
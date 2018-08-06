using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.Models
{
    public class Adotante
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }
        public Especie Especie { get; set; }
        [Required]
        public int EspecieId { get; set; }
        public Porte Porte { get; set; }
        [Required]
        public int PorteId { get; set; }
    }
}
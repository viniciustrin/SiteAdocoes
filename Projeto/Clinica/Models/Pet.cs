using System;
using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public String Raca { get; set; }
        public bool Castrado { get; set; }
        [StringLength(300)]
        public string Observacao { get; set; }
        [Required]
        public bool Adotado { get; set; }
        public bool Vacinado { get; set; }
        public int Idade { get; set; }
        [Required]
        public DateTime DataAlteracao { get; set; }
        public Especie Especie { get; set; }
        [Required]
        public int EspecieId { get; set; }
        public Porte Porte { get; set; }
        [Required]
        public int PorteId { get; set; }
    }
}
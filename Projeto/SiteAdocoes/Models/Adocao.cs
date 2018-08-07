using System;
using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.Models
{
    public class Adocao
    {
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }        
        public Adotante Adotante { get; set; }
        [Required]
        public int  AdotanteId { get; set; }
        
        public Pet Pet { get; set; }
        [Required]
        public int PetId { get; set; }
    }
}
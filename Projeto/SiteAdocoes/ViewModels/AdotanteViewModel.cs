using SiteAdocoes.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteAdocoes.ViewModels
{
    public class AdotanteViewModel: BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }
        [Display(Name = "Espécie de Interesse")]
        [Required]
        public int Especie { get; set; }
        public IEnumerable<Especie> Especies { get; set; }
        [Display(Name = "Porte de Interesse")]
        [Required]
        public int Porte { get; set; }
        public IEnumerable<Porte> Portes { get; set; }
        public IEnumerable<Adotante> Adotantes { get; set; }
        public string Action {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }
        }
    }
}
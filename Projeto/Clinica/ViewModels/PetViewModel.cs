using SiteAdocoes.Controllers;
using SiteAdocoes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace SiteAdocoes.ViewModels
{
    public class PetViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Raça")]
        public string Raca { get; set; }
        public bool Castrado { get; set; }
        [StringLength(300)]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Required]
        public bool Adotado { get; set; }
        public bool Vacinado { get; set; }
        public int Idade { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        [Display(Name = "Espécie")]
        public int Especie { get; set; }
        public IEnumerable<Especie> Especies { get; set; }

        public int Porte { get; set; }
        public IEnumerable<Porte> Portes { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<PetController, ActionResult>> update =
                        (c => c.Update(this));

                Expression<Func<PetController, ActionResult>> create =
                            (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}
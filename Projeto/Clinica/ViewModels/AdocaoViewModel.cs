using SiteAdocoes.Controllers;
using SiteAdocoes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SiteAdocoes.ViewModels
{
    public class AdocaoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime DataAteracao { get; set; }
        [Required]
        public int Adotante { get; set; }
        public IEnumerable<Adotante> Adotantes { get; set; }
        [Required]
        public int Pet { get; set; }
        public IEnumerable<Pet> Pets{ get; set; }
        public IEnumerable<Adocao> Adocoes { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<AdocaoController, ActionResult>> create =
                            (c => c.Create(this));

                var action = create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}
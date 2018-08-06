using SiteAdocoes.Models;
using System.Collections.Generic;

namespace SiteAdocoes.ViewModels
{
    public class HomeViewModel
    {
        public List<PossiveisAdocoes> PossiveisAdocoes { get; set; }

        public bool Autenticado { get; set; }
    }
}
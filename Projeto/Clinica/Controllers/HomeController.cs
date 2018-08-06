using SiteAdocoes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SiteAdocoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Index()
        {

            var pets = _context.Pets.ToList();
            var adotantes = _context.Adotantes.ToList();

            var itens =  from pet in pets
                         join adotante in adotantes on new { pet.EspecieId, pet.PorteId } equals new { adotante.EspecieId, adotante.PorteId }
                         where pet.Adotado == false
                         select new
                         {
                             pet,
                             adotante
                         };

            List<PossiveisAdocoes> possiveisAdocoes = new List<PossiveisAdocoes>();
            foreach (var item in itens)
            {
                possiveisAdocoes.Add(new PossiveisAdocoes {Adotante = item.adotante, Pet = item.pet });
            }

            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            return View(possiveisAdocoes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
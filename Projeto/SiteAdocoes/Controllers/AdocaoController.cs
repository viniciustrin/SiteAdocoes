using SiteAdocoes.Models;
using SiteAdocoes.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SiteAdocoes.Controllers
{
    public class AdocaoController : BaseController
    {

        [Authorize]
        public ActionResult Create()
        {
            var vm = new AdocaoViewModel
            {
                Pets = _context.Pets.ToList(),
                Adotantes = _context.Adotantes.ToList(),
                Adocoes = _context.Adocoes.ToList(),
                Heading = "Adotar um Pet",
                Botao = "Adotar"
            };
            
            return View("AdocaoForm",vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult Create(AdocaoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm = new AdocaoViewModel
                {
                    Pets = _context.Pets.ToList(),
                    Adocoes = _context.Adocoes.ToList(),
                    Adotantes = _context.Adotantes.ToList()
                };
                return View("AdocaoForm", vm);
            }

            var adocao = new Adocao
            {
                Data = System.DateTime.Now,
                AdotanteId = vm.Adotante,
                PetId = vm.Pet
            };

            _context.Adocoes.Add(adocao);
            _context.SaveChanges();
            return RedirectToAction("Create","Adocao");
        }
    }
}
using SiteAdocoes.Models;
using SiteAdocoes.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SiteAdocoes.Controllers
{
    public class AdotanteController : BaseController
    {
        [Authorize]
        public ActionResult Create()
        {
            var vm = new AdotanteViewModel
            {
                Adotantes = _context.Adotantes.ToList(),
                Especies = _context.Especies.ToList(),
                Portes = _context.Portes.ToList(),
                Heading = "Adicionar Adotante",
                Botao = "Adicionar"
                
            };
            return View("AdotanteForm",vm);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdotanteViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Adotantes = _context.Adotantes.ToList();
                vm.Especies = _context.Especies.ToList();
                vm.Portes = _context.Portes.ToList();
                vm.Heading = "Adicionar Adotante";
                vm.Botao = "Adicionar";
                return View("AdotanteForm", vm);
            }


            var adotante = new Adotante
            {
                Nome = vm.Nome,
                Endereco = vm.Endereco,
                Telefone = vm.Telefone,
                EspecieId = vm.Especie,
                PorteId = vm.Porte
            };
            _context.Adotantes.Add(adotante);
            _context.SaveChanges();

            return RedirectToAction("Create", "Adotante");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var adotante = _context.Adotantes.SingleOrDefault(x => x.Id == id);

            if (adotante == null)
                return RedirectToAction("Create", "Adotante");

            var vm = new AdotanteViewModel
            {
                Id = id,
                Nome = adotante.Nome,
                Endereco = adotante.Endereco,
                Telefone = adotante.Telefone,
                Adotantes = _context.Adotantes.ToList(),
                Especie = adotante.EspecieId,
                Porte = adotante.PorteId,
                Especies = _context.Especies.ToList(),
                Portes = _context.Portes.ToList(),
                Heading = "Editar Adotante",
                Botao = "Editar"
            };
            return View("AdotanteForm", vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AdotanteViewModel vm)
        {
            var adotante = _context.Adotantes.SingleOrDefault(x => x.Id == vm.Id);

            if (adotante == null)
                return RedirectToAction("Create", "Adotante");

            adotante.Nome = vm.Nome;
            adotante.Endereco = vm.Endereco;
            adotante.Telefone = vm.Telefone;
            adotante.PorteId = vm.Porte;
            adotante.EspecieId = vm.Especie;

            _context.SaveChanges();

            return RedirectToAction("Create", "Adotante");

        }
    }
}
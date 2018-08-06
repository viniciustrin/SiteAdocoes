using SiteAdocoes.Models;
using SiteAdocoes.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SiteAdocoes.Controllers
{
    public class PetController : BaseController
    {
        [Authorize]
        public ActionResult Create()
        {
            var vm = new PetViewModel
            {
                Pets = _context.Pets.ToList(),
                Portes = _context.Portes.ToList(),
                Especies = _context.Especies.ToList(),
                Heading = "Adicionar Pet",
                Botao = "Adicionar"
            };
            return View("PetForm",vm);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Pets = _context.Pets.ToList();
                vm.Portes = _context.Portes.ToList();
                vm.Especies = _context.Especies.ToList();
                vm.Heading = "Adicionar Pet";
                vm.Botao = "Adicionar";
                return View("PetForm", vm);
            }

            var pet = new Pet
            {
                Nome = vm.Nome,
                Adotado = vm.Adotado,
                Castrado = vm.Castrado,
                DataAlteracao = System.DateTime.Now,
                EspecieId = vm.Especie,
                Idade = vm.Idade,
                Observacao = vm.Observacao,
                Raca = vm.Raca,
                Vacinado = vm.Vacinado,
                PorteId = vm.Porte
            };
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return RedirectToAction("Create", "Pet");

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
                var pet = _context.Pets.Where(x => x.Id == id).FirstOrDefault();

                if (pet == null)
                    return RedirectToAction("Create", "Pet");

                var vm = new PetViewModel
                {
                    Id = id,
                    Nome = pet.Nome,
                    Adotado = pet.Adotado,
                    Castrado = pet.Castrado,
                    DataCriacao = pet.DataAlteracao,
                    Especie = pet.EspecieId,
                    Idade = pet.Idade,
                    Observacao = pet.Observacao,
                    Raca = pet.Raca,
                    Vacinado = pet.Vacinado,
                    Porte = pet.PorteId,
                    Heading = "Editar Pet",
                    Botao = "Editar",
                    Pets = _context.Pets.ToList(),
                    Portes = _context.Portes.ToList(),
                    Especies = _context.Especies.ToList()
                };
                return View("PetForm", vm);           
            
        }



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PetViewModel vm)
        {
            var pet = _context.Pets.Where(x => x.Id == vm.Id).FirstOrDefault();

            if (pet == null)
                return RedirectToAction("Create", "Pet");

            pet.Nome = vm.Nome;
            pet.Adotado = vm.Adotado;
            pet.Castrado = vm.Castrado;
            pet.DataAlteracao = System.DateTime.Now;
            pet.EspecieId = vm.Especie;
            pet.Idade = vm.Idade;
            pet.Observacao = vm.Observacao;
            pet.Raca = vm.Raca;
            pet.Vacinado = vm.Vacinado;
            pet.PorteId = vm.Porte;

            _context.SaveChanges();
            return RedirectToAction("Create", "Pet");

        }

    }
}
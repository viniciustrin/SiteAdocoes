using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiteAdocoes.Api
{
    public class PetController : BaseApiController
    {

        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var pets = _context.Pets.Where(c => c.Adotado == false).Select(c => new PetDTO()
            {
                Id = c.Id,
                Nome = c.Nome,
                Castrado = c.Castrado,
                Especie = c.Especie.NomeEspecie,
                Idade = c.Idade,
                Observacao = c.Observacao,
                Porte = c.Porte.NomePorte,
                Raca = c.Raca,
                Vacinado = c.Vacinado

            });


            return this.Request.CreateResponse(HttpStatusCode.OK, pets);

        }


        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var pet = _context.Pets.Single(x => x.Id == id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();

            return Ok();
        }


        public class PetDTO
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Raca { get; set; }
            public bool Castrado { get; set; }
            public string Observacao { get; set; }
            public bool Vacinado { get; set; }
            public int Idade { get; set; }
            public string Porte { get; set; }
            public string Especie { get; set; }
        }
    }
}

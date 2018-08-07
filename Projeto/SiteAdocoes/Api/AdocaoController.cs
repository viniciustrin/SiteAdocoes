using SiteAdocoes.Models;
using System;
using System.Web.Http;

namespace SiteAdocoes.Api
{
    public class AdocaoController : BaseApiController
    {

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody] Adocao adocao)
        {
            var pet = _context.Pets.Find(adocao.PetId);

            if (pet == null)
            {
                return NotFound();
            }


            var adotante = _context.Adotantes.Find(adocao.AdotanteId);

            if (adotante == null)
            {
                return NotFound();
            }

            try
            {
                adocao.Data = System.DateTime.Now;
                _context.Adocoes.Add(adocao);
                pet.Adotado = true;
                _context.SaveChanges();
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}

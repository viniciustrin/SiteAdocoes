using System.Linq;
using System.Web.Http;

namespace SiteAdocoes.Api
{
    public class AdotanteController : BaseApiController
    {        
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var adotante = _context.Adotantes.Find(id);

            if (adotante == null)
                return NotFound();

            if (_context.Adocoes.SingleOrDefault(x => x.AdotanteId == adotante.Id) != null)
            {
                return BadRequest("Não é possível remover um adotante que já adotou um pet!");
            }

            _context.Adotantes.Remove(adotante);
            _context.SaveChanges();

            return Ok();
        }
    }
}

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
            var adotante = _context.Adotantes.Single(x => x.Id == id);
            _context.Adotantes.Remove(adotante);
            _context.SaveChanges();

            return Ok();
        }
    }
}

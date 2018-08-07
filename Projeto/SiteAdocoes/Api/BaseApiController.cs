
using SiteAdocoes.Models;
using System.Web.Http;

namespace SiteAdocoes.Api
{
    public class BaseApiController : ApiController
    {
        protected readonly ApplicationDbContext _context;

        public BaseApiController()
        {
            _context = new ApplicationDbContext();
        }
    }
}

using SiteAdocoes.Models;
using System.Web.Mvc;

namespace SiteAdocoes.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public BaseController()
        {
            _context = new ApplicationDbContext();            
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
        }
    }
}
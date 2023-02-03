using CadastroUsuarioBL;
using System.Collections.Generic;
using System.Web.Mvc;


namespace CadastroUsuarioMvc.Controllers
{
    public class HomeController : Controller
    {
        private ProcessoBL bl = new ProcessoBL();

        // GET: Processo
        [HttpGet]
        public ActionResult Index()
        {
            List<decimal> list = Session["STATUS_PERMITIDO"] as List<decimal>;
            return View("Index", bl.HomeProcesso(list));
        }
    }
}
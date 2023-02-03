using CadastroUsuarioBL;
using System.Web.Mvc;

namespace CadastroUsuarioMvc.Controllers
{
    public class HistoricoController : Controller
    {
        private HistoricoBL bl = new HistoricoBL();

        // GET: Historico
        public ActionResult Index()
        {
            return View("Index", bl.GetUsuarioProcesso());
        }
    }
}
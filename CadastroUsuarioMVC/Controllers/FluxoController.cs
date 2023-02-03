using CadastroUsuarioBL;
using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroUsuarioMvc.Controllers
{
    public class FluxoController : HomeController
    {
        private FluxoBL bl = new FluxoBL();

        public ActionResult EncaminhaGerente(decimal id)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            bl.EncaminhaGerente(id, id_usuario);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AprovarGerente(decimal id)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            bl.AprovarGerente(id, id_usuario);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AprovarControleRisco(decimal id)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            bl.AprovarControleRisco(id, id_usuario);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Reprovar(decimal id)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            bl.Reprovar(id, id_usuario);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Correcao(decimal id)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            bl.EncaminhaCorrecao(id, id_usuario);
            return RedirectToAction("Index", "Home");
        }
    }
}
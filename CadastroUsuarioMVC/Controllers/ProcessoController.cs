using CadastroUsuarioBL;
using CadastroUsuarioModels;
using System.Web.Mvc;
using System;
using System.Net;

namespace CadastroUsuarioMvc.Controllers
{
    public class ProcessoController : Controller
    {
        private ProcessoBL pBL = new ProcessoBL();
        private CidadeBL cBL = new CidadeBL();
        private FluxoBL fBL = new FluxoBL();

        // GET: Processo
        [HttpGet]
        public ActionResult Index()
        {
            GetPais();
            return View();
        }

        //ESTE METODO FAZ O CADASTRO DE UM PROCESSO
        [HttpPost]
        public ActionResult Cadastrar(Processo processo)
        {
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);

            //ESTA PARTE CADASTRA O PROCESSO E RECEBE UM DECIMAL COMO RETORNO 
            var id_processo =  pBL.CadastrarProcesso(processo);

            //ESTA PARTE FAZ UM GET DO PROCESSO QUE ACABOU DE SER CRIADO E PASSA OS VALORES PRA RASTREABILIDADE
            var novo = pBL.GetProcesso(id_processo);
            fBL.Rastreabilidade(id_processo, id_usuario, novo.Id_Status);
            return RedirectToAction("Index", "Home");
        }

        //METODO FAZ A EXCLUSAO DO PROCESSO
        [HttpGet]
        public ActionResult Excluir(decimal id)
        {
            if (pBL.ExcluirProcesso(id))
                return RedirectToAction("Index", "Home");
            else
                return Content("Algo deu errado");
        }

        //METODO TRÁS OS DETALHES DO PROCESSO
        public ActionResult Detalhes(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processo pROCESSO = pBL.GetProcesso(id);
            if (pROCESSO == null)
            {
                return HttpNotFound();
            }
            return View(pROCESSO);
        }

        //ESTE METODO SERVE PARA DAR VALOR PRA VIEWBAG PARA A VIEW NA HORA DE EDITAR OU INSERIR UM PROCESSO
        public void GetPais()
        {
            ViewBag.GetPais = cBL.GetListaPais();
        }

        //ESTE METODO SERVE PARA DAR VALOR PRA VIEWBAG PARA A VIEW NA HORA DE EDITAR OU INSERIR UM PROCESSO
        public ActionResult GetListaEstado(int id_Pais)
        {
            return Json(new SelectList(cBL.GetListaEstado(id_Pais), "ID_ESTADO", "NOME"), JsonRequestBehavior.AllowGet);
        }

        //ESTE METODO SERVE PARA DAR VALOR PRA VIEWBAG PARA A VIEW NA HORA DE EDITAR OU INSERIR UM PROCESSO
        public ActionResult GetListaCidade(int id_Estado)
        {
            return Json(new SelectList(cBL.GetListaCidade(id_Estado), "ID_CIDADE", "NOME"), JsonRequestBehavior.AllowGet);
        }
    }
}
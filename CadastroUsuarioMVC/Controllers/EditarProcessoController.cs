using CadastroUsuarioBL;
using CadastroUsuarioModels;
using System;
using System.Web.Mvc;

namespace CadastroUsuarioMvc.Controllers
{
    public class EditarProcessoController : ProcessoController
    {
        private ProcessoBL bl = new ProcessoBL();
        private CidadeBL Cbl = new CidadeBL();
        private FluxoBL fBL = new FluxoBL();

        /*METODO SERVE PARA PEGAR O PROCESSO ESCOLHIDO E TRAS TODAS AS INFORMAÇÕES PARA OS CAMPOS*/
        [HttpGet]
        public ActionResult Editar(decimal id)
        {
            Processo processo = bl.GetProcesso(id);

            /*ESTA PARTE SERVE PARA TRAZER AS VIEWBAG DE PAIS, ESTADO E CIDADE*/
            GetPais();
            GetEspecificoEstado(processo.Cidade.Estado.Id_Pais);
            GetEspecificoCidade(processo.Cidade.Estado.Id_Estado);

            return View("Editar", processo);
        }

        //METODO PARA EFETUAR A EDIÇÃO DAQUELE PROCESSO ESPECÍFICO
        [HttpPost]
        public ActionResult Editar(Processo processo)
        {
            processo.Id_Cidade = processo.Cidade.Id_Cidade;
            var id_usuario = Convert.ToDecimal(Session["ID_USUARIO"]);
            var id_status = processo.Id_Status;
            var id_processo = processo.Id_Processo;
            if (bl.PostEditar(processo))
            {
                fBL.Rastreabilidade(id_processo, id_usuario, id_status);
                return RedirectToAction("Index", "Home");
            }
            else
                return Content("Algo deu errado!");
        }

        //METEDO PARA DAR VALOR A VIEWBAG DO ESTADO
        public void GetEspecificoEstado(decimal id_Pais)
        {
            ViewBag.GetEstado = Cbl.GetListaEstado(id_Pais);
        }

        //METEDO PARA DAR VALOR A VIEWBAG DO PAIS
        public void GetEspecificoCidade(decimal id_Estado)
        {
            ViewBag.GetCidade = Cbl.GetListaCidade(id_Estado);
        }
    }
}
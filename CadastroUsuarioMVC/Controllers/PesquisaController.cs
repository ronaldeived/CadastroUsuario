using CadastroUsuarioEntity;
using CadastroUsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroUsuarioMvc.Controllers
{
    public class PesquisaController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Pesquisa
        public ActionResult Pesquisa()
        {
            var _cliente = db.Processo.ToList();
            var data = new ViewModelProcesso()
            {
                Processos = _cliente
            };
            return View(data);
        }

        //ESTE METODO FAZ A PESQUISA DOS PROCESSOS
        [HttpPost]
        public ActionResult Pesquisa(ViewModelProcesso _processoView)
        {
                var processoPesquisa = from processo in db.Processo
                                       where ((_processoView.Nome == null) || (processo.Nome == _processoView.Nome.Trim()))
                                       && ((_processoView.Cpf == 0) || (processo.Cpf == _processoView.Cpf))
                                       select new
                                       {
                                           Id = processo.Id_Processo,
                                           Nome = processo.Nome,
                                           Cpf = processo.Cpf
                                       };
                List<Processo> listaProcesso = new List<Processo>();
                foreach (var reg in processoPesquisa)
                {
                    Processo processo = new Processo();
                    processo.Id_Processo = reg.Id;
                    processo.Nome = reg.Nome;
                    processo.Cpf = reg.Cpf;
                    listaProcesso.Add(processo);
                }
                _processoView.Processos = listaProcesso;
                return View(_processoView);
        }
    }
}
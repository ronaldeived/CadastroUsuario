using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroUsuarioDAL;
using CadastroUsuarioModels;

namespace CadastroUsuarioBL
{
    public class UsuarioBL
    {
        public bool AcessoParaCadastrar(List<PerfilEnum> perfis)
        {
            Int32 a = new Int32();
            foreach (var item in perfis)
            {
                switch (item)
                {
                    case PerfilEnum.Administracao:
                        //Adm
                        a = 1;
                        break;
                    case PerfilEnum.Operacao:
                        //Operação
                        a = 1;
                        break;
                    default:
                        break;
                }
            }
            if (a == 1)
                return true;
            else
                return false;
        }

        public List<decimal> GetStatus(List<PerfilEnum> perfis)
        {
            List<decimal> listaStatus = new List<decimal>();
            foreach (var item in perfis)
            {
                switch (item)
                {
                    case PerfilEnum.Administracao:
                        //Adm
                        List<decimal> statusAdm = new List<decimal>() { 1, 2, 3, 4, 5, 6 };
                        listaStatus = listaStatus.Concat(statusAdm).ToList();
                        break;
                    case PerfilEnum.Gerente:
                        //Gerencia
                        List<decimal> statusGer = new List<decimal>() { 1, 2, 3 };
                        listaStatus = listaStatus.Concat(statusGer).ToList();
                        break;
                    case PerfilEnum.Operacao:
                        //Operação
                        List<decimal> statusOpe = new List<decimal>() { 2, 3, 4, 5 };
                        listaStatus = listaStatus.Concat(statusOpe).ToList();
                        break;
                    case PerfilEnum.Risco:
                        //Controle de risco
                        List<decimal> statusCtr = new List<decimal>() { 2, 3, 6 };
                        listaStatus = listaStatus.Concat(statusCtr).ToList();
                        break;
                    default:
                        break;
                }
            }
            return listaStatus;
        }
    }
}

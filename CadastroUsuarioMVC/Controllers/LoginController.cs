using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CadastroUsuarioBL;
using CadastroUsuarioModels;

namespace CadastroUsuarioMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //ESTE MÉTODO FAZ O LOGIN
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(Autenticar(usuario.Login, usuario.Senha))
                {
                    UsuarioBL u = new UsuarioBL();
                    LoginBL bl = new LoginBL();
                    usuario = bl.Login(usuario.Login, usuario.Senha);
                    //SESSION USADA PARA VER QUAL USUARIO ESTA LOGADO, USADO NOS CONTROLLERS PROCESSO E FLUXO
                    Session["ID_USUARIO"] = Convert.ToInt32(usuario.Id_Usuario);

                    //SESSION PARA MOSTRAR O NOME DA PESSOA LOGADA NO INICIO NA PAGINA HOME
                    Session["NOME"] = usuario.Nome.ToString();
                    
                    //SESSION UTILIZADA PARA LIBERAR ACESSO AO BOTÃO DE CADASTRAR NA PAGINA HOME
                    Session["ID_PERFIL"] = u.AcessoParaCadastrar(usuario.Usuario_Perfis.Select(x => (PerfilEnum)x.Id_Perfil).ToList());
                    
                    /* SESSION UTILIZADA PARA LIBERAR ACESSO A DETERMINADOS BOTÕES QUE CADA 
                    PERFIL DE USUARIO TEM LIBERADO ATRAVES DO STATUS PERMITIDO A CADA UM */
                    Session["STATUS_PERMITIDO"] = u.GetStatus(usuario.Usuario_Perfis.Select(x => (PerfilEnum)x.Id_Perfil).ToList());

                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or password");
                }
            }
            return RedirectToAction("Index", usuario);
        }

        //ESTE MÉTODO SERVE PARA FAZER A AUTENTICAÇÃO DO LOGIN
        public bool Autenticar(string login, string senha)
        {
            LoginBL bl = new LoginBL();
            Usuario usuario = bl.Login(login, senha);
            if (usuario != null)
            {   
                FormsAuthentication.RedirectFromLoginPage(usuario.Login, false);
                return true;
            }
            else
                return false;
        }

        //METODO QUE PEGA A SESSION[ID_USUARIO] E MANDA PARA A PAGINA HOME
        public ActionResult UserDashBoard()
        {
            if (Session["ID_USUARIO"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
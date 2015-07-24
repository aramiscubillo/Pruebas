using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WPP.Entities.Objects.Generales;
using WPP.Helpers;
using WPP.Models;
using WPP.Security;
using WPP.Service.ModuloContratos;

namespace WPP.Controllers
{
    public class UsuarioController : BaseController
    {

        private IUsuarioService usuarioService;
        private IWPPMembershipProvider wppMemberShipProvider;

        public UsuarioController(IUsuarioService service, IWPPMembershipProvider WPPMemberProvider)
        {
            try
            {
                this.usuarioService = service;
                wppMemberShipProvider = WPPMemberProvider;
            }
            catch (Exception ex)
            {
                
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult Index()
        {
                return View();
        }


        [HttpGet]
        public ActionResult CrearUsuario()
        {
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View();
        }


        


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login, string returnUrl)
        {
            Usuario usuario = wppMemberShipProvider.ValidateUser(login.Email, login.Password);
            if (ModelState.IsValid == true && usuario != null)
            {
               WPPConstants.Usuario = usuario; 
                FormsAuthentication.SetAuthCookie(login.Email, true);
                return RedirectURL(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "The email or password provided is incorrect.");
                return View(login);
            }
        }


        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }


        private ActionResult RedirectURL(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WPP.Entities.Objects.Generales;
using WPP.Helpers;
using WPP.Models;
using WPP.Models.Generales;
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
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROLES_ADMINISTRACION)]
        public ActionResult Index()
        {
            ViewBag.UsuariosList = usuarioService.ListAll();
            IList<UsuarioModel> models = new List<UsuarioModel>();
            UsuarioModel temp = null;

            foreach (var item in usuarioService.ListAll())
            {
                temp = new UsuarioModel();
                temp.Id = item.Id;
                temp.Nombre = item.Nombre;
                temp.Apellido = item.Apellidos;
                temp.Email = item.Email;
                temp.FechaNac = item.FechaNac;
                temp.Roles = item.Roles;

                models.Add(temp);
            }

            ViewBag.UsuariosList = models;
            
            return View("Index");
        }


        [HttpGet]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult CrearUsuario()
        {
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View();
        }


        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult CrearUsuario(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Nombre = usuario.Nombre;
                nuevoUsuario.Apellidos = usuario.Apellido;
                nuevoUsuario.Email = usuario.Email;
                nuevoUsuario.Password = usuario.Password;
                nuevoUsuario.Roles = usuario.Roles;
                nuevoUsuario.FechaNac = usuario.FechaNac;
                nuevoUsuario.Version = 1;
                nuevoUsuario.CreateDate = DateTime.Now;
                nuevoUsuario.DateLastModified = DateTime.Now;

                usuarioService.Create(nuevoUsuario);

                ViewBag.Mensaje = "Se ha creado el usuario";

                return Index();
            }
            else
            {
                ViewBag.Roles = WPPConstants.ListaRoles;
                return View();
            }
        }


        [HttpGet]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult EditarUsuario(Guid idUsuario)
        {
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login, string returnUrl)
        {
            Usuario usuario = wppMemberShipProvider.ValidateUser(login.Email, login.Password);

            if (ModelState.IsValid && usuario != null)
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WPP.Entities.Objects.Generales;
using WPP.Helpers;
using WPP.Security;
using WPP.Service.ModuloContratos;
using WPP.Mapper;
using WPP.Model;
using WPP.Model.General;

namespace WPP.Controllers
{
    public class UsuarioController : BaseController
    {

        private IUsuarioService usuarioService;
        private IWPPMembershipProvider wppMemberShipProvider;
        private UsuarioMapper usuarioMapper;

        public UsuarioController(IUsuarioService service, IWPPMembershipProvider WPPMemberProvider)
        {
            try
            {
                
                this.usuarioService = service;
                wppMemberShipProvider = WPPMemberProvider;
                usuarioMapper = new UsuarioMapper();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
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
            try
            {
                ViewBag.UsuariosList = usuarioService.ListAll();
                IList<UsuarioModel> models = new List<UsuarioModel>();

                foreach (var item in usuarioService.ListAll())
                {
                    models.Add(usuarioMapper.GetUsuarioModel(item));            
                }

                ViewBag.UsuariosList = models;  

				
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            
            return View("Index");

        }


        [HttpGet]
       // [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult CrearUsuario()
        {
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View();
        }


        //[AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult CrearUsuario(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario = usuarioMapper.GetUsuario(usuario);
                nuevoUsuario.Version = 1;
                nuevoUsuario.CreateDate = DateTime.Now;
                nuevoUsuario.DateLastModified = DateTime.Now;
                nuevoUsuario.Password = WPPHelper.MD5Encryptor(nuevoUsuario.Password);

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

        [HttpPost]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult Delete(UsuarioModel model, bool confirmed)
        {
            try
            {
                if (confirmed)
                {

                    Usuario usuario = usuarioService.Get(model.Id);
                    usuario.IsDeleted = true;
                    usuarioService.Update(usuario);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Ha ocurrido un error al eliminar la información";
                   
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "Ha ocurrido un error al eliminar la información";
                logger.Error(ex.Message);
            }
            return null;
        }

        [HttpGet]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult EditarUsuario(Guid idUsuario)
        {
            UsuarioMapper mapper = new UsuarioMapper();
            UsuarioModel usuario = mapper.GetUsuarioModel(usuarioService.Get(idUsuario));
            String testing  = DateTime.Now.ToShortDateString();
            testing+="";
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View(usuario);
        }



        [HttpPost]
        [AccessDeniedAuthorizeAttribute(Roles = WPPConstants.ROL_SUPER_USUARIO)]
        public ActionResult EditarUsuario(UsuarioModel usuarioModel)
        {
 
            Usuario usuario = usuarioService.Get(usuarioModel.Id);

            usuario.Nombre = usuarioModel.Nombre;
            usuario.Apellidos = usuarioModel.Apellidos;
            usuario.DateLastModified = DateTime.Now;
            usuario.Email = usuarioModel.Email;
            usuario.FechaNac = usuarioModel.FechaNac;
            usuario.Roles = usuarioModel.Email;
            usuario.Version++;

            usuarioService.Update(usuario);

            ViewBag.Roles = WPPConstants.ListaRoles;
            return Index();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login, string returnUrl)
        {
            string password = WPPHelper.MD5Encryptor(login.Password);
            if (ModelState.IsValid && wppMemberShipProvider.ValidateUser(login.Email, password))
            {
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

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
using WPP.Models;

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
            ViewBag.UsuariosList = usuarioService.ListAll();
            IList<UsuarioModel> models = new List<UsuarioModel>();

            foreach (var item in usuarioService.ListAll())
            {
                models.Add(usuarioMapper.GetUsuarioModel(item));            
            }

            ViewBag.UsuariosList = models;
            
            return View();
        }


        [HttpGet]
        public ActionResult CrearUsuario()
        {
            ViewBag.Roles = WPPConstants.ListaRoles;
            return View();
        }


        public ActionResult CrearUsuario(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario = usuarioMapper.GetUsuario(usuario);
                nuevoUsuario.Version = 1;
                nuevoUsuario.CreateDate = DateTime.Now;
                nuevoUsuario.DateLastModified = DateTime.Now;

                usuarioService.Create(nuevoUsuario);

                return View("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login, string returnUrl)
        {
             Usuario usuario = wppMemberShipProvider.ValidateUser(login.Email, login.Password);
            if (ModelState.IsValid && usuario!=null)
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

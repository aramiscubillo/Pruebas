using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPP.Security;
using WPP.Service.BaseServiceClasses;
using WPP.Service.ModuloContratos;
using WPP.Mapper;
using WPP.Model;
using WPP.App_Start;
using WPP.Entities.Objects.Generales;

namespace WPP.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        private IUsuarioService usuarioService;
        private ICompaniaService companiaService;
        

        //public HomeController(ICompaniaService service)
        //{
        //    try
        //    {
        //        this.companiaService = service;
        //        this.logger.Debug("prueba");
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message);
        //    }
        //}

        public HomeController(IUsuarioService service)
        {
            try
            {
                this.usuarioService = service;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        [AccessDeniedAuthorizeAttribute(Roles = "SuperUser")]
        public ActionResult TestMethod()
        {
            return View();
        }


        [AccessDeniedAuthorizeAttribute(Roles = "Admin")]

        public ActionResult Index()
        {
        //  CompaniaMapper companiaMapper = new CompaniaMapper();
        //  Compania compania = companiaService.Create(new Compania { Nombre = "Compania 2", Cedula = "456", Id = new Guid() });
          // CompaniaModel companiaModel = companiaMapper.GetCompaniaModel(compania);


            String f = "";
            f += "";
            usuarioService.Create(new Usuario { Id = new Guid(), Nombre = "Usuario1" });



           return View("Index");//, companiaModel
        }

    }
}

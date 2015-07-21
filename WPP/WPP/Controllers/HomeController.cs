using Entities.WPPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPP.Service.BaseServiceClasses;
using WPP.Service.ModuloContratos;

namespace WPP.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        private IUsuarioService usuarioService;
        private ICompaniaService companiaService;

        public HomeController(ICompaniaService service)
        {
            this.companiaService = service;
        }


        public ActionResult Index()
        {
            companiaService.Create(new Compania { Nombre = "Compania 1", Cedula = "123" });
           // var data = companiaService.Get(1);

            return View("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPP.Service.BaseServiceClasses;
using WPP.Service.ModuloContratos;
using WPP.Mapper;
using WPP.Model;
using WPP.Entities.Base;

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
          CompaniaMapper companiaMapper = new CompaniaMapper();
          Compania compania = companiaService.Create(new Compania { Nombre = "Compania 2", Cedula = "456" });
           CompaniaModel companiaModel = companiaMapper.GetCompaniaModel(compania);


           return View("Index", companiaModel);
        }

    }
}

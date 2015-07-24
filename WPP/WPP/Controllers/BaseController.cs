using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPP.Service.BaseServiceClasses;

namespace WPP.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        public readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
                UnitOfWork.BeginTransaction();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                if (!filterContext.IsChildAction)
                    UnitOfWork.Commit();
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

    }
}

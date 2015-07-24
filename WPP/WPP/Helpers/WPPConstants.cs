using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPP.Helpers
{
    public class WPPConstants
    {
        public static String ROL_ADMINISTRADOR = "Administrador";

        public static String ROL_SUPER_USUARIO = "Super Usuario";

        public static IList<String> ListaRoles = new List<String> { ROL_ADMINISTRADOR, ROL_SUPER_USUARIO };

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPP.Entities.Objects.Generales;

namespace WPP.Helpers
{
    public class WPPConstants
    {
        public  const String ROL_ADMINISTRADOR = "Administrador";

        public  const String ROL_SUPER_USUARIO = "Super Usuario";

        public const String ROLES_ADMINISTRACION = "Super Usuario, Administrador";

        public const String ROL_ = "Super Usuario";

        public static readonly  String[] ListaRoles = { ROL_ADMINISTRADOR, ROL_SUPER_USUARIO };

    }
}
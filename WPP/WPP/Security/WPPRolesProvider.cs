using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WPP.Entities.Objects.Generales;
using WPP.Helpers;

namespace WPP.Security
{
    public class WPPRolesProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

   

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Usuario usuario = WPPConstants.Usuario;

            return usuario.Roles.Split(',');

            //switch (username)
            //{
                   
            //    case "aramis.cubillo@yahoo.com":
            //            return new[]{"Manager", "Admin"};
            //    case "dbarboza@sapiens.co.cr":
            //            return new[] { "Manager", "Admin" };  
            //    default:
            //        return new string[]{};
            //}
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
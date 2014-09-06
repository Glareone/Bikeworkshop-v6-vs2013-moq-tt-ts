using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Client.PrincipalRealization
{
    public class CustomPrincipal:ICustomPrincipal
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public IIdentity Identity { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username"></param>
        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }
        
        /// <summary>
        /// Check user role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string conditionstate)
        {
            var Rolelist = new List<Role>();
            //If user are logIn
            if (Identity != null)
            {
                Rolelist = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(Identity.Name);
            }
            else return false;
            //check user permissions and role names to check is user may user concrete function where method "IsInRole" called.
            foreach (var role in Rolelist)
            {
                if (role.Name == conditionstate || role.Permissions.Contains(conditionstate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

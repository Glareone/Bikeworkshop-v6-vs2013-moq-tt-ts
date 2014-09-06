using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.ASP.Controllers.Interfaces;

namespace Training.Workshop.ASP.Controllers
{
    public class UserPageController:IUserPageController
    {
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User AddUser(string username, string password,string[] roles)
        {
           return User.Create(username, password,roles);
        }
        /// <summary>
        /// returns all roles which user has
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<string> GetRolesbyUsername(string username)
        {
            return User.GetPermissionsbyRoleName(username);
        }
    }
}

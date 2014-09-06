using System;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class User : Entitybase
    {
        /// <summary>
        /// User's name / login
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User's role
        /// </summary>
        public List<Role> Roles { get; set; }
        /// <summary>
        /// override Equals method because User are reference type
        /// used in .Equal(user) method and listofusers.Contains(user)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = (User)obj;

            if (other != null)
            {

                if (Username == other.Username)
                {
                    foreach (var role in Roles)
                    {
                        if (!other.Roles.Contains(role))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// override gethashcode because Equals is overriding too.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string roletostr = "";

            string permissiontostr = "";

            foreach (var role in Roles)
            {
                roletostr += role.Name;
                foreach (var permission in role.Permissions)
                {
                    permissiontostr += permission;
                }
            }
            return string.Format("{0}_{1}_{2}", Username, roletostr, permissiontostr).GetHashCode();
        }


        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static User Create(string username, string password, string[] roles)
        {
            return ServiceLocator.Resolve<IUserService>().Create(username, password, roles);
        }
        /// <summary>
        /// Delete user with current username if he exist in database
        /// </summary>
        /// <returns></returns>
        public static void Delete(string username)
        {
            ServiceLocator.Resolve<IUserService>().Delete(username);
        }

        public static List<User> GetAllUsers()
        {
            return ServiceLocator.Resolve<IUserService>().GetAllUsers();
        }

        /// <summary>
        /// Returns completely constructing user with roles and permissions
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            return ServiceLocator.Resolve<IUserService>().GetUser(username);
        }


        /// <summary>
        /// Login function,read user if he exist in database or return guest user if is not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetUser(string username, string password)
        {
            return ServiceLocator.Resolve<IUserService>().GetUser(username, password);
        }
        /// <summary>
        /// Get permissions by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Role> GetUserRolesandPermissions(string username)
        {
            return ServiceLocator.Resolve<IUserService>().GetRolesandPermissionsbyUsername(username);
        }
        /// <summary>
        /// returns permission list which role with rolename has in database
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public static List<string> GetPermissionsbyRoleName(string rolename)
        {
            return ServiceLocator.Resolve<IUserService>().GetPermissionsbyRoleName(rolename);
        }
    }
}
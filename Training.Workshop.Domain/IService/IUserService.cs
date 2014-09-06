using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        User Create(string username, string password, string[] roles);
        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        void Delete(string username);
        /// <summary>
        /// reads user with current username,check the password and return user if he exist in database, else return empty user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUser(string username, string password);
        /// <summary>
        /// Get user with permissions and roles by username. New method executing by 
        /// 1 stored procedure
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);
        /// <summary>
        /// returns all users with roles and permissions. Actual method works 
        /// by using 1 stored procedure
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
        /// <summary>
        /// return all roles with permisions which user has
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<Role> GetRolesandPermissionsbyUsername(string username);
        /// <summary>
        /// returns permission list which role has in database
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        List<string> GetPermissionsbyRoleName(string rolename);
    }
}
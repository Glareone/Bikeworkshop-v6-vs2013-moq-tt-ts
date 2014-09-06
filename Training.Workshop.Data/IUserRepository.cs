using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Data
{
    public interface IUserRepository
    {
        /// <summary>
        /// Saves user into repository
        /// </summary>
        /// <param name="user"></param>
        bool SaveNewUser(string username, string password, string[] role);

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        void DeleteUser(string username);
        /// <summary>
        /// Get all user information
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
        User RetrieveUser(string username);
        /// <summary>
        /// Returns all users with permissions and roles.
        /// New method works with 1 stored procedure.
        /// </summary>
        /// <returns></returns>
        List<User> RetrieveAllUsers();
        /// <summary>
        /// returns all permissions for 1 role
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        List<string> GetPermissionsbyRolename(string rolename);
        /// <summary>
        /// return all role names which user obtained
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        List<string> GetRoleNamesByUsername(string username);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<Role> GetRolesandPermissionsbyUsername(string username);
        /// <summary>
        /// return all users with permissions from database
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
        /// <summary>
        /// return userid by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetUserIDbyUsername(string username);
    }
}
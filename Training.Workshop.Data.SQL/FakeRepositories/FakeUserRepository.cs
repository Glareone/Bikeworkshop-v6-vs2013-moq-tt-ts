using System.Collections.Generic;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    /// <summary>
    /// Fake repository for testing
    /// </summary>
    public class FakeUserRepository: IUserRepository
    {
        /// <summary>
        /// Saves user into repository
        /// </summary>
        /// <param name="username">user's name</param>
        /// <param name="password">user password</param>
        /// <param name="role">user roles</param>
        public bool SaveNewUser(string username, string password, string[] role)
        {
            // TODO
            // Need realization
            return true;
        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            // TODO
            // Need realization
        }

        /// <summary>
        /// Get all user information
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string username, string password)
        {
            // TODO
            // Need realization
            return new User();
        }

        /// <summary>
        /// Get user with permissions and roles by username. New method executing by 
        /// 1 stored procedure
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User RetrieveUser(string username)
        {
            //TODO
            //need realization
            return new User();
        }

        /// <summary>
        /// Returns all users with permissions and roles.
        /// New method works with 1 stored procedure.
        /// </summary>
        /// <returns></returns>
        public List<User> RetrieveAllUsers()
        {
            //TODO
            //need realization
            return new List<User>();
        }

        /// <summary>
        /// returns all permissions for 1 role
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public List<string> GetPermissionsbyRolename(string rolename)
        {
            //TODO
            //need realization
            return new List<string>();
        }

        /// <summary>
        /// return all role names which user obtained
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<string> GetRoleNamesByUsername(string username)
        {
            //TODO
            //need realization
            return new List<string>();
        }

        /// <summary>
        /// Get permissions,put it into roles and returns list of role.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            //TODO
            //need realization
            return new List<Role>();
        }

        /// <summary>
        /// return all users with permissions from database
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            //TODO
            //need realization
            return new List<User>();
        }

        /// <summary>
        /// return userid by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserIDbyUsername(string username)
        {
            //TODO
            //need realization
            return new int();
        }

    }
}

using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

namespace Training.Workshop.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public virtual User Create(string username, string password, string[] roles)
        {
            //If user created correctly return User with roles and permissions, else return empty user
            if (Data.Context.Current.RepositoryFactory.GetUserRepository().
                SaveNewUser(username, password, roles))
            {
                return GetUser(username, password);
            }
            else
            {
                return new User();
            }

        }
        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        public virtual void Delete(string username)
        {
            Data.Context.Current.RepositoryFactory.GetUserRepository()
                .DeleteUser(username);
        }
        /// <summary>
        /// reads user with current username,check the password and return user if he exist in database, else return empty user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual User GetUser(string username, string password)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetUser(username, password);
        }
        /// <summary>
        /// Get user with permissions and roles by username. New method executing by 
        /// 1 stored procedure
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        public virtual List<User> GetAllUsers()
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().RetrieveAllUsers();
        }

        public virtual User GetUser(string username)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().RetrieveUser(username);
        }

        /// <summary>
        /// return list of permissions that role with rolename has
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public virtual List<string> GetPermissionsbyRoleName(string rolename)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetPermissionsbyRolename(rolename);
        }
        /// <summary>
        /// return all role with included permissions that user with username has
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(username);
        }

    }
}

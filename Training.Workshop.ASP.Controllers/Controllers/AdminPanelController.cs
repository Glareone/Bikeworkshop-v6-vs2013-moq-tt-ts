using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers
{
    public class AdminPanelController:IAdminPanelController
    {
        /// <summary>
        /// Add new user that not exist in database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public User AddNewUser(string username, string password,string[] role)
        {
            return User.Create(username, password,role);
        }
        /// <summary>
        /// Delete all existing users with this username.
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            Data.Context.Current.RepositoryFactory.GetUserRepository().DeleteUser(username);
        }
        /// <summary>
        /// Return all users with Name-Role-Permissions but without passwords.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetAllUsers();
        }
        /// <summary>
        /// Added new roles to updating user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newroles"></param>
        /// <returns></returns>
        public User UpdateUserRole(string username, string password, string[] newroles)
        {
            //TODO
            //Need realization
            return new User();
        }

        public List<Bike> GetAllBikes()
        {
            return Bike.Search();
        }

        /// <summary>
        /// Change password to existing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        public User UpdateUserPassword(string username, string password, string newpassword)
        { 
            //Update User in database. GetUser->UpdateUser

            //TODO
            //need realization
            return new User();
        }
        /// <summary>
        /// Add new roles to existing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newroles"></param>
        /// <returns></returns>
        User UpdateuserRole(string username, string password, string[] newroles)
        {
            //TODO
            //need realization
            return new User();
        }

        /// <summary>
        /// Add new bike to database
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="bikeyear"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Bike AddNewBike(string manufacturer, string mark, int bikeyear, int ownerID, string condition)
        {
            //TODO
            //need realization
            return new Bike();
        }
        /// <summary>
        /// Update Condition from existing bike
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="newcondition"></param>
        /// <returns></returns>
        public void UpdateExistingBike(string manufacturer, string mark, int ownerID,string condition, string newcondition)
        {
            Bike.UpdateCondition(manufacturer, mark, ownerID,condition, newcondition);
            //TODO
            //need realization
        }
    }
}

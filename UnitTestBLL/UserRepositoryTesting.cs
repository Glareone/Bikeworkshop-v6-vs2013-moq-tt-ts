using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Data;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.UnitTestBLL
{
    [TestClass]
    public class UserRepositoryTesting
    {
        [TestMethod]
        public void UserRepositoryTestMethod()
        {
            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            //new data of tries
            var randomel = new Random();

            string existingusername = "glareone";

            string NewUser = "";

            for (int i = 0; i < 20; i++)
            {
                NewUser += Convert.ToChar(randomel.Next(65, 90));
            }


            string password = "glareone";

            string[] rolearraywith1role = { "consumer" };

            string[] rolearraywith2roles = { "consumer", "administrator" };

            string[] rolearraywith3roles = { "administrator", "manager", "consumer" };
            //Testing SaveNewUser(name,pas,roles[]) method
            //Try to add existing user in database
            Assert.IsFalse(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(existingusername, password, rolearraywith1role)
                , "User are exist,but method adding new user with same name");

            //Try to add new user in database
            Assert.IsTrue(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(NewUser, password, rolearraywith1role), "User creates not correct");

            //Testing GetUser(name,pas)
            var user = Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetUser(NewUser, password);

            Assert.IsInstanceOfType(user, typeof(User), "GetUser returns not User");

            Assert.AreEqual(user.Username, NewUser, "User from GetUser(name,password) are incorrect");

            List<Role> listofuserroles = Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(NewUser);
            //Testing GetUser and GetRolesandPermissonsbyUsername methods
            Assert.IsTrue(user.Roles.Count == listofuserroles.Count, "count of roles is not equal");

            foreach (var el in user.Roles)
            {
                Assert.IsTrue(listofuserroles.Contains(el), "something wrong with roles");
            }
            foreach (var el in listofuserroles)
            {
                Assert.IsTrue(user.Roles.Contains(el), "something wrong with roles");
            }


            //Testing GetAllUsers() and correct writing to database 
            List<User> listofuser = Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetAllUsers();



            Assert.IsTrue(listofuser.Contains(user), "User are not added to database");

            //Testing retrieveallusers() Method
            List<User> listofuser2 = Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().RetrieveAllUsers();

            Assert.IsTrue(listofuser2.Count != 0, "Database is Empty after adding new user");

            Assert.IsTrue(listofuser2.Contains(user), "user are not added to database or retrieve all users are incorrect");

            //Check equals of old methods which based on 1 and 3 stored procedures
            Assert.AreEqual(
                Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().RetrieveUser(NewUser),
                Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetUser(NewUser, password));
        }
    }
}

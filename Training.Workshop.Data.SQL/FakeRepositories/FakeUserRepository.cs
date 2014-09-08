

namespace Training.Workshop.Data.SQL
{
    using System.Collections.Generic;
    using Training.Workshop.Domain.Entities;
    using System;
    using System.IO;
    using System.Text;

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
            var rand = new Random();

            var salt = string.Empty;

            byte[] hash;

            var passwordwithsaltSHA = string.Empty;


            for (int j = 0; j < rand.Next(8, 15); j++)
            {
                salt += Convert.ToChar(rand.Next(65, 90));
            }

            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password + salt));
            }
            var stringbuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringbuilder.AppendFormat("{0:x2}", b);
            }
            passwordwithsaltSHA = stringbuilder.ToString();

            using (var streamwriter = 
                new StreamWriter(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.Data.SQL\FakeUserData.txt", true))
            {
                streamwriter.WriteLine(username + " " + passwordwithsaltSHA + " " + salt);
            }
            return true;
        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            var listofusers = new List<string>();

            // Read all data and delete strokes contains username
            using (
                var streamreader =
                    new StreamReader(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.Data.SQL\FakeUserData.txt"))
            {
                var line = string.Empty;

                while ((line = streamreader.ReadLine()) != null)
                {
                    listofusers.Add(line);    
                }

                listofusers.RemoveAll(x => x.Contains(username));
            }

            // Overwriten data to file
            using (var streamwriter = 
                    new StreamWriter(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.Data.SQL\FakeUserData.txt", false))
            {
                foreach (var el in listofusers)
                {
                    streamwriter.WriteLine(el);    
                }
                
            }
        }

        /// <summary>
        /// Get user information
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
        /// <param name="rolename">
        /// rolename which user has
        /// </param>
        /// <returns></returns>
        public List<string> GetPermissionsbyRolename(string rolename)
        {
            // TODO
            // need realization
            return new List<string>();
        }

        /// <summary>
        /// return all role names which user obtained
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// </returns>
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
            // TODO
            // need realization
            return new List<Role>();
        }

        /// <summary>
        /// return all users with permissions from database
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            // TODO
            // need realization
            return new List<User>();
        }

        /// <summary>
        /// return userid by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserIDbyUsername(string username)
        {
            // TODO
            // need realization
            return new int();
        }

        private List<string> GetFakeUsers(int count)
        {
            var listoffakeusers = new List<string>();

            using (var streamreader = new StreamReader(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.Data.SQL\FakeUserData2.txt"))
            {                
                var line = string.Empty;

                for (int i = 0; i < count; i++)
                {                    
                    if ((line = streamreader.ReadLine()) != null)
                    {
                      listoffakeusers.Add(line);
                    }
                }   
            }
            return listoffakeusers;
        }

    }
}
